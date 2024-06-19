namespace pizza_project.Interfaces;

public interface IPizza
{

    public DateTime Date { get; set; }
    public List<Pizza> GetAll();
    public Pizza? Get(int id);
    public void Add(Pizza pizza);
    public List<Pizza>? Delete(int id);
    public bool UpDate(Pizza pizza);

}