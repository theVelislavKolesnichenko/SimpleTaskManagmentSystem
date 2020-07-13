namespace SimpleTaskManagmentSystem.Domain.Models.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Tasks;

    public class User : Entity<int>
    {
        private readonly HashSet<Task> tasks;

        public User(int id, string username, string password, string displayName)
        {
            Id = id;
            Username = username;
            Password = password;
            DisplayName = displayName;
            tasks = new HashSet<Task>();
        }

        public string Username { get; }
        public string Password { get; }
        public string DisplayName { get; }

        public IReadOnlyCollection<Task> Tasks => this.tasks.ToList().AsReadOnly();
        internal void AddTask(Task task) => this.tasks.Add(task);
    }
}
