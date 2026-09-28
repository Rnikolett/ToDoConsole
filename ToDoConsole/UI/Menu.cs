using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoConsole.Models;
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

                //TODO a caseket függvényekbe kiszervezni

                switch (menuswitch)
                {
                    case "1":
                        TodoService.NewTaskInteraction();
                        break;

                    case "2":
                        Console.WriteLine("\nEdit is not yet available\n");
                        break;

                    case "3":
                        TodoService.Delete();
                        break;

                    case "4":
                        TodoService.PrintTasks();
                        break;

                    case "5":
                        canExit = TodoService.saveExit();
                        if (canExit)
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        
    }
}
