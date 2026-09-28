using ToDoConsole.Models;

namespace ToDoConsole.Services
{
    public class TodoService
    {
        public static void AddTask(string title, string? description, DateTime duedate, PriorityLevels priority)
        {
            Storage.ToDoList.Add(new TodoItem(GenerateID(), title, description, duedate, priority));
        }

        public static int GenerateID()
        {
            int newID = 1;
            foreach (var item in Storage.ToDoList)
            {
                if (item.Id >= (newID))
                {
                    newID = (item.Id + 1);
                }
            }
            return newID;
        }

        //TODO complete Task
        //TODO overdue

        public static void PrintTasks()
        {
            foreach (var item in Storage.ToDoList)
            {
                Console.WriteLine($"Id: {item.Id}");
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Is it completed: {item.IsCompleted}");
                Console.WriteLine($"Due Date: {item.DueDate}");
                Console.WriteLine($"Priority: {item.Priority}\n");
            }
        }

        public static void CreateTask()
        {
            string title = GetTitle();

            Console.WriteLine("Description:\n");
            string? description = Console.ReadLine();

            Console.WriteLine("Priority?\n" +
                "Low\n" +
                "Medium\n" +
                "High\n");
            PriorityLevels priority = GetPriority();

            DateTime dueDate = GetDate();

            AddTask(title, description, dueDate, priority);
        }

        private static string GetTitle()
        {
            string? title = null;
            while (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("\nName of the item:\n");
                title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("No name");
                }
            }
            return title;
        }

        private static PriorityLevels GetPriority()
        {
            PriorityLevels priorityLevel = PriorityLevels.Low;
            bool hasPriority = false;
            while (!hasPriority)
            {
                Console.WriteLine("Priority?\n" +
                    "Low\n" +
                    "Medium\n" +
                    "High\n");

                string? priority = Console.ReadLine();

                if (!Enum.TryParse(priority, true, out priorityLevel))
                {
                    Console.WriteLine("not defined priority");
                }
                else
                {
                    hasPriority = true;
                }
            }
            return priorityLevel;
        }

        private static DateTime GetDate()
        {
            bool validDate = false;
            DateTime dueDate = DateTime.Now;
            while (!validDate)
            {
                Console.WriteLine("Enter a Due Date: [YYYY.MM.DD] -> [2021.12.01]\n");
                string? input = Console.ReadLine();
                if (DateTime.TryParse(input, out dueDate))
                {
                    if (dueDate >= DateTime.Today)
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
            PrintTasks();
            Console.WriteLine("The ID of you would want to delete:\n");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                for (int i = 0; i < Storage.ToDoList.Count; i++)
                {
                    if (Storage.ToDoList[i].Id == id)
                    {
                        string title = Storage.ToDoList[i].Title;
                        Storage.ToDoList.Remove(Storage.ToDoList[i]);
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

        public static bool SaveExit()
        {
            Console.WriteLine("Would you like to exit? Y/N\n");
            string? exit = Console.ReadLine();
            if (exit != null && exit.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Would you like to save? Y/N\n");
                string? save = Console.ReadLine();
                if (save != null && save.Equals("y", StringComparison.OrdinalIgnoreCase))
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
