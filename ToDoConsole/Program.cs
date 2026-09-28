using ToDoConsole.Services;
using ToDoConsole.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Menu.MenuInteractions();
        Console.WriteLine();
        TodoService.PrintTasks();
    }
}