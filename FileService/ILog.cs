namespace pizza_project.FileService;

public interface ILog
{
    public string FilePath { get; set; }
    public void WriteMessage<T>(T message);
}