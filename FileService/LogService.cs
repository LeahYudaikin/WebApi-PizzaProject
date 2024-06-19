using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pizza_project.FileService;

public class LogService:ILog
{
    public string FilePath { get; set; }

    public LogService()
    {
        this.FilePath = Path.Combine(Environment.CurrentDirectory, "files", "myLog.txt");
    }

    public void WriteMessage<T>(T message)
    {
        if(File.Exists(FilePath))
        {
            File.AppendAllText(FilePath , $"{message}");
        }
    }
}