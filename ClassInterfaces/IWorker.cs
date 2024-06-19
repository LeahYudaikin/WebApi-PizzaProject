namespace pizza_project.Interfaces;

public interface IWorker
{

    public DateTime Date { get; set; }
    public List<Worker> GetAll();
    public Worker? Get(int id);
    public void Add(Worker worker);
    public List<Worker>? Delete(int id);

}