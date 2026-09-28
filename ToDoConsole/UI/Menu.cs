using ToDoConsole.Services;

namespace ToDoConsole.UI
{
    public class Menu
    {
        public static void MenuInteractions()
        {
            bool canExit = false;
            while (!canExit)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1 - New task\n" +
                    "2 - Edit task\n" +
                    "3 - Delete task\n" +
                    "4 - Show tasks\n" +
                    "5 - Save and Exit\n");
                string? menuswitch = Console.ReadLine();
                Console.WriteLine("\n");

                switch (menuswitch)
                {
                    case "1":
                        TodoService.CreateTask();
                        break;

                    case "2":
                        Console.WriteLine("\nEdit is not yet available\n"); //TODO edit
                        break;

                    case "3":
                        TodoService.Delete();
                        break;

                    case "4":
                        TodoService.PrintTasks();
                        break;

                    case "5":
                        canExit = TodoService.SaveExit();
                        break;
                }
            }
        }
    }
}
