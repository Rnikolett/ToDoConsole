using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoConsole.Models;
using ToDoConsole.UI;

namespace ToDoConsole.Services
{
    public class TodoService
    {
        private static List<TodoItem> todoItems = new List<TodoItem>();
        //TODO complete Task
        public static void AddTask(string title, string? description, DateTime? duedate, PriorityLevels priority)
        {
            Storage.toDoList.Add(new TodoItem(generateID(), title, description, duedate, priority));

        }
        public static int generateID()
        {
            int newID = 1;
            foreach (var item in Storage.toDoList)
            {
                if (item.Id >= (newID))
                {
                    newID = (item.Id + 1);
                }
            }
            return newID;
        }

        //TODO overdue

        public static void PrintTasks()
        {
            foreach (var item in Storage.toDoList)
            {
                Console.WriteLine($"Id: {item.Id}");
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Is it completed: {item.IsCompleted}");
                Console.WriteLine($"Due Date: {item.DueDate}");
                Console.WriteLine($"Priority: {item.Priority}\n");
            }
        }

        public static void NewTaskInteraction()
        {
            string? title = getTitle();

            Console.WriteLine("Description:\n");
            string? description = Console.ReadLine();

            Console.WriteLine("Priority?\nLow\nMedium\nHigh\n");
            PriorityLevels priority = getPriority();

            DateTime dueDate = getDate();


            TodoService.AddTask(title, description, dueDate, priority);

        }
        private static string getTitle()
        {
            bool hasname = false;
            string title = null;
            while (!hasname)
            {
                Console.WriteLine("\nName of the item:\n");
                title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("No name");

                }
                else
                {
                    hasname = true;
                }
            }
            return title;
        }

        private static PriorityLevels getPriority()
        {
            PriorityLevels priorityLevel = PriorityLevels.Low;
            bool hasPriority = false;
            while (!hasPriority)
            {

                Console.WriteLine("Priority?\n" +
                    "Low\n" +
                    "Medium\n" +
                    "High\n");

                string priority = Console.ReadLine();

                if (!(Enum.TryParse<PriorityLevels>(priority, true, out var result)))
                {
                    Console.WriteLine("not defined priority");
                }
                else
                {
                    priorityLevel = Enum.Parse<PriorityLevels>(priority, true);
                    hasPriority = true;
                }
            }
            return priorityLevel;
        }
        private static DateTime getDate()
        {
            bool validDate = false;
            DateTime dueDate = DateTime.Now;
            while (!validDate)
            {
                Console.WriteLine("Enter a Due Date: [YYYY.MM.DD] -> [2021/12/01]\n");
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out _))
                {
                    dueDate = DateTime.Parse(input);
                    if (dueDate - DateTime.Now.Date >= TimeSpan.Zero)
                    {
                        validDate = true;
                    }
                    else
                    {
                        Console.WriteLine("The date has been passed");
                    }
                }
                else
                {
                    Console.WriteLine("invalid Date\n");
                }
            }
            return dueDate;
        }

        public static void Delete()
        {
            int id;
            PrintTasks();
            Console.WriteLine("The ID of you would want to delete:\n");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _))
            {
                id = int.Parse(input);

                for (int i = 0; i < Storage.toDoList.Count; i++)
                {
                    if (Storage.toDoList[i].Id == id)
                    {
                        string title = Storage.toDoList[i].Title;
                        Storage.toDoList.Remove(Storage.toDoList[i]);
                        Console.WriteLine($"{title} has been deleted\n");
                    }
                    else Console.WriteLine("Not found\n");
                }
            }
            else
            {
                Console.WriteLine("Could not delete\n");
            }
        }

        public static bool saveExit()
        {
            Console.WriteLine("Would you like to exit? Y/N\n");
            String exit = Console.ReadLine().ToLower();
            if (exit == "y")
            {
                Console.WriteLine("Would you like to save? Y/N\n");
                String save = Console.ReadLine().ToLower();
                if (save == "y")
                {
                    Storage.SaveToFile();
                    Console.WriteLine("Progress is saved\n");
                    return true;
                }
                else
                {
                    Console.WriteLine("Exited without saving\n");
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
