using System.Text.Json;
using ToDoConsole.Models;

namespace ToDoConsole.Services
{
    public class Storage
    {
        private const string path = "C:\\Users\\User\\source\\repos\\ToDoConsole\\ToDoConsole\\Data\\TodoList.json";
        public static List<TodoItem> ToDoList { get; private set; } = ReadFromFile();
        public static void SaveToFile()
        {
            string SaveFile = JsonSerializer.Serialize(ToDoList);
            File.WriteAllText(path, SaveFile);
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
            return new List<TodoItem>(); 
        }
    }
}
