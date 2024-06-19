using pizza_project.Interfaces;
using pizza_project.FileService;

namespace pizza_project.Services;

public class WorkerService:IWorker
{
    public DateTime Date { get; set; }
    private IFile _file;
    string path = Path.Combine(Environment.CurrentDirectory, "files", "workerFile.json");
    public List<Worker> Workers { get; set; }

    public WorkerService(IFile file)
    {
        Date = DateTime.Now;
        _file = file;
        Workers = _file.Get<Worker>(path);
    }

    public List<Worker> GetAll()
    {
        Workers =  _file.Get<Worker>(path);
        return Workers;
    } 

    public Worker? Get(int id)
    {
        return GetAll().FirstOrDefault(w => w.Id == id);
    } 

    public void Add(Worker worker)
    { 
        worker.Id = GetAll().Last().Id+1;
        _file.AddItem<Worker>(worker, path);
    }

    public List<Worker>? Delete(int id)
    {
        foreach ( var worker in Workers )
        {
            if(worker.Id == id)
            {
                Workers.Remove(worker);
                _file.UpDate(Workers, path);
                return Workers;
            }
        }
        return null;
    }

}