namespace SimpleTaskManagmentSystem.Wpf.Commands
{
    using SimpleTaskManagmentSystem.Application.Contracts.Services;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using SimpleTaskManagmentSystem.Infrastructure.Services;
    using SimpleTaskManagmentSystem.Wpf.ViewModels;
    using System;
    using System.Collections.ObjectModel;

    public class SearchCommentCommand : Command
    {
        private ICommentService commentService;

        private BoardViewModel BordViewModel { get; set; }
        public SearchCommentCommand(BoardViewModel bordViewModel) 
        {
            commentService = new CommentService();
            BordViewModel = bordViewModel;
        }

        public async override void Execute(object parameter)
        {
            string search = parameter.ToString();

            var comments = await commentService.GetComments(search);

            BordViewModel.FilteredComments = new ObservableCollection<Comment>(comments);
        }
    }
}
