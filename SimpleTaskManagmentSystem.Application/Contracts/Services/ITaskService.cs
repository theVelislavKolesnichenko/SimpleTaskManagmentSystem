namespace SimpleTaskManagmentSystem.Application.Contracts.Services
{
    using Domain.Models.Tasks;
    using System.Collections.Generic;
    public interface ITaskService
    {
        System.Threading.Tasks.Task<IEnumerable<Task>> GetTasks();
        System.Threading.Tasks.Task<int> Insert(Task task);
        System.Threading.Tasks.Task<bool> Update(Task task);
    }
}
