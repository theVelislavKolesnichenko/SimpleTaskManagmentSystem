using Microsoft.VisualBasic.CompilerServices;
using SimpleTaskManagmentSystem.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTaskManagmentSystem.Wpf.Commands
{
    public class CloseTaskViewCommand : Command
    {
        private BoardViewModel borderViewModel;

        public CloseTaskViewCommand(BoardViewModel borderViewModel)
        {
            this.borderViewModel = borderViewModel;
        }

        public override void Execute(object parameter)
        {
            borderViewModel.TaskViewWidth = 0;
            borderViewModel.Tasks.Insert(0, borderViewModel.SelectedTask);
            //save changis
        }
    }
}
