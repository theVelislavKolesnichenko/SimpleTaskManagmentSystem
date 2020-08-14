namespace SimpleTaskManagmentSystem.Application.Contracts.Repositories
{
    using Domain.Models.Tasks;
    using System.Collections.Generic;
    public interface ITaskRepository
    {
        public IEnumerable<Task> GetTasks();
        public int Insert(Task task);
        public bool Update(Task task);
    }
}
