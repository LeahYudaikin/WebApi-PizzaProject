using pizza_project.Interfaces;
using pizza_project.FileService;

namespace pizza_project.Services;

public class OrderService:IOrder
{
    public DateTime Date { get; set; }
    private IFile _file;
    string path = Path.Combine(Environment.CurrentDirectory, "files", "orderFile.json");
    string pizza_path = Path.Combine(Environment.CurrentDirectory, "files", "pizzaFile.json");

    public List<Order> Orders { get; set; }
    public OrderService(IFile file)
    {
        Date = DateTime.Now;
        _file = file;
        Orders = _file.Get<Order>(path);
    }

    public List<Order> GetAll()
    {
        Orders = _file.Get<Order>(path);
        return Orders;
    } 

    public Order? Get(int id)
    {
        return GetAll().FirstOrDefault(o => o.Id == id);
    } 

    public async void AddOrder(Order order)
    {
        order.Id = GetAll().Last().Id+1;
        Task<Order> T = Payment(order);
        MakePizza(order.Items);
        Order o = await T;
        SendEmail(o);
    }

    public List<Order>? Delete(int id)
    {
        foreach(var order in Orders)
        {
            if(order.Id == id)
            {
                Orders.Remove(order);
                _file.UpDate(Orders, path);
                return Orders;
            }
        }
        return null;
    }

    public async Task<Order> Payment(Order order)
    {
        await Task.Delay(5000);

        foreach(var item in order.Items)
        {
            List<Pizza> Pizzas = _file.Get<Pizza>(pizza_path);
            Pizza pizza = Pizzas.FirstOrDefault(i => item.PizzaId == i.Id);
            if (pizza != null)
            order.TotalPrice += item.Amount * pizza.Price;
        }
        _file.AddItem(order, path);
        Console.WriteLine( "✅ payment : Successfully");
        return order;
    }

    public void MakePizza(List<Item> Items)
    {
        if (Items == null)
            return;
        foreach(var item in Items)
        {
            if (item != null)
            {
                List<Pizza> Pizzas = _file.Get<Pizza>(pizza_path);
                Pizza pizza = Pizzas.FirstOrDefault(i => item.PizzaId == i.Id);
                for (int i = 0; i < item.Amount; i++)
                {
                    Task.Delay(4000).Wait();
                    Console.WriteLine("🍕 pizza is ready: "+ "Id: " + pizza.Id + ", Name: " + pizza.Name);
                }  
            }          
        }
    }

    public void SendEmail(Order order)
    {
        List<Pizza> Pizzas = _file.Get<Pizza>(pizza_path);
        string str = $"Id: {order.Id}, Date: {order.Date}\n";
        foreach(Item item in order.Items)
        {
            Pizza p = Pizzas.FirstOrDefault(p => p.Id == item.PizzaId);
            str+= $"pizza's Id: {item.PizzaId}, pizza's Name: {p.Name}, Quantity: {item.Amount}, Price: {item.Amount*p.Price}\n";
        }
        str += order.Name +" Thenk you‼️ payment get successfull: "+ order.TotalPrice +"₪\n";
        string pathMail = Path.Combine(Environment.CurrentDirectory, "files/Mails", "Order"+order.Id+".txt");
        _file.WriteObject(str, pathMail);
        Console.WriteLine("📧Send a mail to: "+order.Mail);
    }

}