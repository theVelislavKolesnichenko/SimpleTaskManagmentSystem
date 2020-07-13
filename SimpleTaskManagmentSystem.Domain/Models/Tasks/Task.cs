namespace SimpleTaskManagmentSystem.Domain.Models.Tasks
{
    using Common;
    using SimpleTaskManagmentSystem.Domain.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Task : Entity<int>
    {
        public HashSet<Comment> comments;

        public User user; 

        public Task(int id, DateTime createdDate, DateTime requiredByDate, string description, Status status, Type type)
        {
            Id = id;
            CreatedDate = createdDate;
            RequiredByDate = requiredByDate;
            Description = description;
            Status = status;
            Type = type;
            comments = new HashSet<Comment>();
            user = default!;
        }

        public DateTime CreatedDate { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Type Type { get; set; }

        public IReadOnlyCollection<Comment> Comments => comments.ToList().AsReadOnly();

        public void AddComment(Comment comment) => this.comments.Add(comment);

        public void AssignedTo(User user)
        {
            this.user = user;
            this.user.AddTask(this);
        }
    }
}
