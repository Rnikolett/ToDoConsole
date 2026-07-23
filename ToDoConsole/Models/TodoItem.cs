using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DateTime? DueDate { get; set; }
        public PriorityLevels Priority { get; set; }

        public TodoItem(int id, string title, string? description, DateTime? duedate, PriorityLevels priority)
        {
            Id = id; //required
            Title = title; //required
            Description = description; //otional
            IsCompleted = false; //set not completed
            CreatedAt = DateTime.Now.Date; //set today
            DueDate = duedate; //optional?
            Priority = priority; //optional? - set Low
        }
    }
}
