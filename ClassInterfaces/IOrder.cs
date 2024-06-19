namespace pizza_project.Interfaces;

public interface IOrder
{
    public DateTime Date { get; set; }
    public List<Order> GetAll();
    public Order? Get(int id);
    public void AddOrder(Order order);
    public List<Order>? Delete(int id);
}