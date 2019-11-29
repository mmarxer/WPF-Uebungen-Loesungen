using System;

namespace TodoList
{
    public class TodoItem
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string DeadlineAsString => Deadline.ToString("dd.MM.yyyy");
        public bool IsDone { get; set; }
        public bool IsOpen => !IsDone;

        public TodoItem() { }

        public TodoItem(string description, DateTime deadline, bool isDone = false)
        {
            Description = description;
            Deadline = deadline;
            IsDone = isDone;
        }
    }
}
