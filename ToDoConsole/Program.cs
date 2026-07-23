using ToDoConsole.Models;
using ToDoConsole.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        TodoService.AddTask(new TodoItem(1, "Nya", "none", new DateTime(2026, 08, 12), PriorityLevels.Low));
        TodoService.AddTask(new TodoItem(2, "Nyapata", "", new DateTime(2026, 08, 12), PriorityLevels.High));
        TodoService.PrintTasks();
    }
}