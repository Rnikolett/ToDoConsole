using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoConsole.Models;

namespace ToDoConsole.Services
{
    public class TodoService
    {
        private static List<TodoItem> todoItems = new List<TodoItem>();
        
        public static void AddTask(TodoItem task)
        {
            todoItems.Add(task);
            Storage.SaveToFile(todoItems);
        }
        //TODO delete
        //TODO overdue
        public static void PrintTasks()
        {
            Console.WriteLine(todoItems.Count + " item \n");
            Storage.ReadFromFile();
            //foreach (TodoItem item in todoItems)
            //{
            //    Console.WriteLine("Title: " + item.Title 
            //        + "\nDescription: " + item.Description 
            //        + "\nCeated at: " + item.CreatedAt 
            //        + "\nDue Date: " + item.DueDate 
            //        + "\nCompleted: " + item.IsCompleted 
            //        + "\nPriority: " + item.Priority + "\n");
            //}
        }
        public static void Delete()
        {

        }
        
    }
}
