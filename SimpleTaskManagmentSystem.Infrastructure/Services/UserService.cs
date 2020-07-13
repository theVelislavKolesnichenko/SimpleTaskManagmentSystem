namespace SimpleTaskManagmentSystem.Infrastructure.Services
{
    using Application.Contracts.Services;
    using Application.Features;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class UserService : IUserService
    {
        private readonly HttpClient client = WebClient.Instance.client;
        public async Task<AuthenticateResponse> Login(AuthenticateRequest request)
        {
            AuthenticateResponse user = null;

            HttpResponseMessage response = await client.PostAsJsonAsync("users/authenticate", request);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<AuthenticateResponse>();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + user.Token);
            }

            return user;
        }
    }
}
