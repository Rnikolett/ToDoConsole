using ToDoConsole.Models;
using ToDoConsole.Services;
using ToDoConsole.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //TodoService.AddTask(new TodoItem(6, "nyaronen", "none", new DateTime(2026, 08, 12), PriorityLevels.High));
        Menu.MenuInteractions();
        Console.WriteLine();
        TodoService.PrintTasks();
    }
}