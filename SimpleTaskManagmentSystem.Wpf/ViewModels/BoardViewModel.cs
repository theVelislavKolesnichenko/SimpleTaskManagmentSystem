namespace SimpleTaskManagmentSystem.Wpf.ViewModels
{
    using SimpleTaskManagmentSystem.Application.Features;
    using SimpleTaskManagmentSystem.Domain.Common;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using SimpleTaskManagmentSystem.Wpf.Commands;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class BoardViewModel : ViewModelBase
    {
        public AuthenticateResponse User { get; set; }

        #region taskView

        private int taskViewWidth;

        public int TaskViewWidth
        {
            get => taskViewWidth;
            set
            {
                taskViewWidth = value;
                OnPropertyChanged();
            }
        }

        public ICommand CloseTaskViewCommand { get; }

        #endregion

        private TaskViewModel selectedTask;

        public TaskViewModel SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public ICommand DeleteTaskCommand { get; }

        public ICommand AddTaskCommand { get; }

        public ObservableCollection<Type> TaskTypes { get; set; } 
        public ObservableCollection<CommentType> CommentTypes { get; set; }

        public ObservableCollection<TaskViewModel> tasks;
        public ObservableCollection<TaskViewModel> Tasks 
        { 
            get 
            { 
                return tasks; 
            } 
            set 
            { 
                tasks = value; 
                OnPropertyChanged();
            } 
        }

        public ICommand AddCommentCommand { get; }

        public ICommand AssignmentToCommand { get; }

        private string searchText;

        public string SearchComment
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommentCommand { get; }

        public ObservableCollection<Comment> FilteredComments { get; set; }

        public BoardViewModel() 
        {
            this.selectedTask = new TaskViewModel();

            TaskTypes = new ObservableCollection<Type>(Enumeration.GetAll<Type>());
            CommentTypes = new ObservableCollection<CommentType>(Enumeration.GetAll<CommentType>());

            CloseTaskViewCommand = new CloseTaskViewCommand(this);
            AddTaskCommand = new AddTaskCommand(this);

            SearchCommentCommand = new SearchCommentCommand(this);
        }

        public BoardViewModel(AuthenticateResponse user, ObservableCollection<TaskViewModel> tasks) : this()
        {
            User = user;
            Tasks = tasks;
        }
    }
}
