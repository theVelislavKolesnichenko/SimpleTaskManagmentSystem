namespace SimpleTaskManagmentSystem.Wpf.ViewModels
{
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using System;
    using System.Windows;

    public class CommentViewModel : ViewModelBase
    {
        public string Content { get; }
        public int OwnerId { get; set;}
        public int CurrontUser { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime ReminderDate { get; }
        public CommentType Type { get; }

        public Visibility Visibility 
        {
            get 
            {
                return (OwnerId != CurrontUser)
                    ? Visibility.Hidden 
                    : Visibility.Visible;
            }
        }
    }
}
