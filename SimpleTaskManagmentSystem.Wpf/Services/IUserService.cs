namespace SimpleTaskManagmentSystem.Wpf.Services
{
    using SimpleTaskManagmentSystem.Wpf.Services.Model;
    using System.Threading.Tasks;
    public interface IUserService
    {
        public Task<AuthenticateResponse> Login(AuthenticateRequest request);
    }
}
