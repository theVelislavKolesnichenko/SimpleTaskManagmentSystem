namespace SimpleTaskManagmentSystem.Application.Contracts.Repositories
{
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using System.Collections.Generic;
    public interface ICommentRepository
    {
        public IEnumerable<Comment> Get(string searchText);
    }
}
