namespace SimpleTaskManagmentSystem.Domain.Models.Tasks
{
    using Common;
    using System;
    using Users;
    
    public class Comment : Entity<int>
    {
        public Comment(string content, User owner, Task task, DateTime createdDate, DateTime reminderDate, CommentType type)
        {
            Content = content;
            Owner = owner;
            Task = task;
            CreatedDate = createdDate;
            ReminderDate = reminderDate;
            Type = type;
        }

        public Comment(string content, int taskId, DateTime createdDate, DateTime reminderDate, CommentType type)
        {
            TaskId = taskId;
            Content = content;
            CreatedDate = createdDate;
            ReminderDate = reminderDate;
            Type = type;
            Owner = default!;
            Task = default!;
        }

        public string Content { get; set; }
        public User Owner { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ReminderDate { get; set; }
        public CommentType Type { get; set; }
    }
}
