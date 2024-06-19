using pizza_project.Interfaces;
using pizza_project.FileService;

namespace pizza_project.Services;

public class PizzaService:IPizza
{
    public DateTime Date { get; set; }
    private IFile _file;
    string path = Path.Combine(Environment.CurrentDirectory, "files", "pizzaFile.json");
    public List<Pizza> Pizzas { get; set; }
    public PizzaService(IFile file)
    {
        Date = DateTime.Now;
        _file = file;
        Pizzas = _file.Get<Pizza>(path);
    }

    public List<Pizza> GetAll()
    {
        Pizzas = _file.Get<Pizza>(path);
        return Pizzas;
    } 

    public Pizza? Get(int id)
    {
        return GetAll().FirstOrDefault(p => p.Id == id);
    } 

    public void Add(Pizza pizza)
    {
        pizza.Id = GetAll().Last().Id+1;
        _file.AddItem<Pizza>(pizza, path);
    }

    public List<Pizza>? Delete(int id)
    {
        foreach(var pizza in Pizzas)
        {
            if(pizza.Id == id)
            {
                Pizzas.Remove(pizza);
                _file.UpDate(Pizzas, path);
                return Pizzas;
            }
        }
        return null;
    } 

    public bool UpDate(Pizza pizza)
    {
        foreach(var p in Pizzas)
        {
            if(p.Id == pizza.Id)
            {
                p.Id = pizza.Id;
                p.Name = pizza.Name;
                p.Price = pizza.Price;
                p.Gluten = pizza.Gluten;
                _file.UpDate(Pizzas, path);
                return true;
            }
        }
        return false;
    }

}