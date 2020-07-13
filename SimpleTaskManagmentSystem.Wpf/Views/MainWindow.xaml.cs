namespace SimpleTaskManagmentSystem.Wpf
{
    using SimpleTaskManagmentSystem.Application.Contracts.Services;
    using SimpleTaskManagmentSystem.Application.Features;
    using SimpleTaskManagmentSystem.Infrastructure.Services;
    using SimpleTaskManagmentSystem.Wpf.ViewModels;
    using SimpleTaskManagmentSystem.Wpf.Views;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserService userService;
        private ITaskService taskService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            userService = new UserService();
            taskService = new TaskService();
            try
            {
                var user = await userService.Login(new AuthenticateRequest(passwordBox.Password, usernameBox.Text));

                if (user != null)
                {
                    var tasks = await taskService.GetTasks();

                    var viewModel = new ObservableCollection<TaskViewModel>(tasks.Select(t => new TaskViewModel(t)));

                    BoardWindow boardWindow = new BoardWindow();
                    boardWindow.DataContext = new BoardViewModel(user, viewModel);
                    boardWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter login data again");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please enter login data again");
            }
            
        }
    }
}
