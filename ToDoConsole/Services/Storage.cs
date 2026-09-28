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
        internal static List<TodoItem> toDoList = ReadFromFile(); // gets the item from the file, this is what we are working with
        public static void SaveToFile()
        {
            string SaveFile = JsonSerializer.Serialize(toDoList);
            File.WriteAllText(path, SaveFile);
        }
        public static void AppendToFile(TodoItem newItem)
        {
            string jsonString = File.ReadAllText(path);
            List<TodoItem> todoitem = JsonSerializer.Deserialize<List<TodoItem>>(jsonString) ?? new List<TodoItem>();
            jsonString = JsonSerializer.Serialize(todoitem);
            File.WriteAllText(path, jsonString);

            toDoList.Add(newItem);
            //string SaveFile = JsonSerializer.Serialize(data);
            //File.AppendAllText(path, SaveFile);
        }

        //reads the items from the json file
        public static List<TodoItem> ReadFromFile()
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                List<TodoItem>? todoitem = JsonSerializer.Deserialize<List<TodoItem>>(jsonString);
                if (todoitem != null)
                {
                    
                    return todoitem;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
                return null;
        }

    }
}
