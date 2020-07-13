namespace SimpleTaskManagmentSystem.Application.Contracts.Services
{
    using Domain.Models.Tasks;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICommentService
    {
        public Task<IEnumerable<Comment>> GetComments(string searchText);
    }
}
