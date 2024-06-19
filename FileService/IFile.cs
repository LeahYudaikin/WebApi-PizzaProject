namespace pizza_project.FileService;

public interface IFile
{
    public void WriteObject(string message, string path);
    public void AddItem<T>(T item, string path);
    public List<T> Get<T>(string path);
    public void UpDate<T>(List<T> list, string path);
}