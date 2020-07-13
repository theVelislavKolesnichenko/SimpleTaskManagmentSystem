namespace SimpleTaskManagmentSystem.Application.Contracts.Services
{
    using Domain.Models.Tasks;
    using System.Collections.Generic;
    public interface ITaskService
    {
        public System.Threading.Tasks.Task<IEnumerable<Task>> GetTasks();
    }
}
