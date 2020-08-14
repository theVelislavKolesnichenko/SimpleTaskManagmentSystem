namespace SimpleTaskManagmentSystem.Wpf.ViewModels
{
    using SimpleTaskManagmentSystem.Domain.Common;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using SimpleTaskManagmentSystem.Domain.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.WindowsRuntime;

    public class TaskViewModel : ViewModelBase
    {
        public TaskViewModel(int id, DateTime createdDate, DateTime requiredByDate, string description, Status status, Domain.Models.Tasks.Type type)
        {
            Id = id;
            CreatedDate = createdDate;
            RequiredByDate = requiredByDate;
            Description = description;
            this.Status = status;
            Type = type;
            Comments = new HashSet<CommentViewModel>();
            User = default!;
        }

        public TaskViewModel() : this(
                  0,
                  DateTime.Now, 
                  DateTime.Now.AddDays(1), 
                  "New Task Description", 
                  Status.Open,
                  Domain.Models.Tasks.Type.Task) { }

        public TaskViewModel(Task t) : this(t.Id, t.CreatedDate, t.RequiredByDate, t.Description, t.Status, t.Type) { }

        private int id;

        public int Id 
        {
            get 
            {
                return id;
            }
            set 
            {
                id = value;
                OnPropertyChanged();
            }
        }
        public string Category
        {
            get 
            {
                return Status.Name;
            }
            set
            {
                Status = Enumeration.FromName<Status>(value);
                OnPropertyChanged();
            }
        }

        private DateTime createdDate;
        public DateTime CreatedDate 
        {
            get 
            {
                return createdDate;
            }
            set 
            {
                createdDate = value;
                OnPropertyChanged();
            }
        }
        private DateTime requiredByDate;
        public DateTime RequiredByDate 
        {
            get 
            {
                return requiredByDate;        
            }
            set 
            {
                requiredByDate = value;
                OnPropertyChanged();
            } 
        }
        private string description;
        public string Description
        {
            get 
            {
                return description;
            }
            set 
            {
                description = value;
                OnPropertyChanged();
            } 
        }
        private Status statu;
        public Status Status 
        { 
            get 
            {
                return statu;
            } 
            set 
            {
                statu = value;
                OnPropertyChanged();
            } 
        }
        private Domain.Models.Tasks.Type type;
        public Domain.Models.Tasks.Type Type 
        {
            get 
            {
                return type;
            }
            set 
            {
                type = value;
                OnPropertyChanged();
            }
        }
        private HashSet<CommentViewModel> comments;
        public HashSet<CommentViewModel> Comments 
        {
            get 
            {
                return comments;
            }
            set 
            {
                comments = value;
                OnPropertyChanged();
            }
        }
        private User user;
        public User User 
        {
            get 
            {
                return user;
            } 
            set 
            { 
                user = value; 
            } 
        }

        private Comment comment { get; set; }
        public Comment Comment { get; set; }
    }
}
