using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace pizza_project.FileService;

public class FileService : IFile
{
    public void WriteObject(string message, string path)
    {
        File.WriteAllText(path, $"{message}");
    }

    public void AddItem<T> (T item, string path)
    {
        string json = File.ReadAllText(path);
        var TList = JsonSerializer.Deserialize<List<T>>(json);
        TList.Add(item);
        json = JsonSerializer.Serialize(TList);
        WriteObject(json, path);
    }

    public List<T> Get<T>(string path)
    {
        if(!File.Exists(path))
        {
            return new List<T>();
        }
        string json = File.ReadAllText(path);
        var TList = JsonSerializer.Deserialize<List<T>>(json);
        if (TList != null)
            return TList;
        return default(List<T>);
    }

    public void UpDate<T>(List<T> list, string path)
    {
        string json = JsonSerializer.Serialize(list);
        this.WriteObject(json, path);
    }
}