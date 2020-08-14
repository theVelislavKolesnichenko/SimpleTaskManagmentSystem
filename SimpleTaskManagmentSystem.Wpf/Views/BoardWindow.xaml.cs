namespace SimpleTaskManagmentSystem.Wpf.Views
{
    using SimpleTaskManagmentSystem.Wpf.ViewModels;
    using Syncfusion.UI.Xaml.Kanban;
    using System.Windows;
    /// <summary>
    /// Interaction logic for BoardWindow.xaml
    /// </summary>
    public partial class BoardWindow : Window
    {
        public BoardWindow()
        {
            InitializeComponent();
        }

        private void SfKanban_OnCardTapped(object sender, KanbanTappedEventArgs e)
        {
            //click ot card
            var viewModel = (BoardViewModel)DataContext;
            viewModel.SelectedTask = (TaskViewModel)e.SelectedCard.Content;
            viewModel.TaskViewWidth = 350;
        }
        private void SfKanban_CardDragEnd(object sender, KanbanDragEndEventArgs e)
        {
            //updata state
            var viewModel = (BoardViewModel)DataContext;
            string cate = e.TargetKey.ToString();
        }
    }
}
