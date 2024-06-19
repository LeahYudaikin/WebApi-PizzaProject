namespace pizza_project;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public int TotalPrice { get; set; }
    public List<Item>? Items { get; set; }
    public Payment? CreditCard { get; set; }
}

public class Item
{
    public int PizzaId { get; set; }
    public int Amount { get; set; }
}

public class Payment
{
    public string? Number { get; set; }
    public string? Validity { get; set; }
    public string? ThreeDigits { get; set; }
}