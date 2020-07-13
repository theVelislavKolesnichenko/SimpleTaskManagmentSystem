using SimpleTaskManagmentSystem.Domain.Models.Tasks;
using SimpleTaskManagmentSystem.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManagmentSystem.Wpf.Commands
{
    public class AddTaskCommand : Command
    {
        private BoardViewModel borderViewModel { get; set; }

        public AddTaskCommand(BoardViewModel borderViewModel)
        {
            this.borderViewModel = borderViewModel;
        }

        public override void Execute(object parameter)
        {
            borderViewModel.SelectedTask = new TaskViewModel();
            borderViewModel.TaskViewWidth = 250;

        }
    }
}
