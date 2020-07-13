namespace SimpleTaskManagmentSystem.Wpf.ViewModels
{
    using SimpleTaskManagmentSystem.Domain.Common;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using SimpleTaskManagmentSystem.Domain.Models.Users;
    using System;
    using System.Collections.Generic;
    public class TaskViewModel : ViewModelBase
    {
        public TaskViewModel(string summary, DateTime createdDate, DateTime requiredByDate, string description, Status status, Domain.Models.Tasks.Type type)
        {
            this.Summary = summary;
            CreatedDate = createdDate;
            RequiredByDate = requiredByDate;
            Description = description;
            this.Status = status;
            Type = type;
            Comments = new HashSet<CommentViewModel>();
            User = default!;
        }

        public TaskViewModel() : this(
                  "Task Summary",
                  DateTime.Now, 
                  DateTime.Now.AddDays(1), 
                  "New Task Description", 
                  Status.Open,
                  Domain.Models.Tasks.Type.Task) { }

        public TaskViewModel(Task t) : this(t.Description, t.CreatedDate, t.RequiredByDate, t.Description, t.Status, t.Type) { }

        public string Category
        {
            get 
            {
                return Status.Name;
            }
            set
            {
                Status = Enumeration.FromName<Status>(value);
            }
        }

        public string Summary { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Domain.Models.Tasks.Type Type { get; set; }
        public HashSet<CommentViewModel> Comments { get; set; }
        public User User { get; set; }

        public Comment Comment { get; set; }
    }
}
