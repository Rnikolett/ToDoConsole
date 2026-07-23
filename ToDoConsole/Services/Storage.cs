using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using ToDoConsole.Models;

namespace ToDoConsole.Services
{
    public class Storage
    {
        private static string path = "C:\\Users\\User\\source\\repos\\ToDoConsole\\ToDoConsole\\Data\\TodoList.json";
        public static void SaveToFile(List<TodoItem> data)
        {
            string SaveFile = JsonSerializer.Serialize(data);
            File.WriteAllText(path, SaveFile);
        }
        public static void AppendToFile(List<TodoItem> data)
        {
            //string SaveFile = JsonSerializer.Serialize(data);
            //File.AppendAllText(path, SaveFile);
        }
        public static void ReadFromFile()
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                List<TodoItem>? todoitem = JsonSerializer.Deserialize<List<TodoItem>>(jsonString);
                if (todoitem != null)
                {
                    foreach (var item in todoitem)
                    {
                        Console.WriteLine($"Title: {item.Title}");
                        Console.WriteLine($"Description: {item.Description} \n");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

    }
}
