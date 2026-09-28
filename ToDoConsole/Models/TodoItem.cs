using System.Text.Json.Serialization;

namespace ToDoConsole.Models
{
    public enum PriorityLevels
    {
        Low,
        Medium,
        High
    }
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public PriorityLevels Priority { get; set; }
        [JsonIgnore] //attribute
        public bool OverDue => DueDate < DateTime.Today; // get only property

        public TodoItem(int id, string title, string? description, DateTime duedate, PriorityLevels priority)
        {
            Id = id; //required
            Title = title; //required
            Description = description; //otional
            IsCompleted = false; //set not completed
            CreatedAt = DateTime.Today; //set today
            DueDate = duedate; //optional?
            Priority = priority; //optional? - set Low
        }
    }
}
