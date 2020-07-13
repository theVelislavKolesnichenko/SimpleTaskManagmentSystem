namespace SimpleTaskManagmentSystem.Application.Contracts.Repositories
{
    using Application.Features;
    using Domain.Models.Users;
    using System.Collections.Generic;
    public interface IUserRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
    }
}
