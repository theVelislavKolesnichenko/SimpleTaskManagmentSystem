namespace SimpleTaskManagmentSystem.Application.Contracts.Services
{
    using SimpleTaskManagmentSystem.Application.Features;
    using System.Threading.Tasks;
    public interface IUserService
    {
        public Task<AuthenticateResponse> Login(AuthenticateRequest request);
    }
}
