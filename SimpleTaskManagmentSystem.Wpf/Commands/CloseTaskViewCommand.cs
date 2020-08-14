namespace SimpleTaskManagmentSystem.Wpf.Commands
{
    using SimpleTaskManagmentSystem.Infrastructure.Services;
    using SimpleTaskManagmentSystem.Wpf.ViewModels;
    using System.Data;

    public class CloseTaskViewCommand : Command
    {
        private BoardViewModel borderViewModel;

        public CloseTaskViewCommand(BoardViewModel borderViewModel)
        {
            this.borderViewModel = borderViewModel;
        }

        public async override void Execute(object parameter)
        {
            borderViewModel.TaskViewWidth = 0;
            var task = new Domain.Models.Tasks.Task(
                        borderViewModel.SelectedTask.Id,
                        borderViewModel.SelectedTask.CreatedDate,
                        borderViewModel.SelectedTask.RequiredByDate,
                        borderViewModel.SelectedTask.Description,
                        borderViewModel.SelectedTask.Status,
                        borderViewModel.SelectedTask.Type);

            if (task.Id == 0)
            {
                int resultId = await new TaskService().Insert(task);

                if(resultId > 0)
                {
                    borderViewModel.SelectedTask.Id = resultId;
                    borderViewModel.Tasks.Insert(0, borderViewModel.SelectedTask);
                }
                //Insert in DB            
            }
            else 
            {
                await new TaskService().Update(task);
                //Update in DB
            }
        }
    }
}
