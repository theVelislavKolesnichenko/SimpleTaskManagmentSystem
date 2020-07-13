namespace SimpleTaskManagmentSystem.Application.Features
{
    using SimpleTaskManagmentSystem.Domain.Models.Users;
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
            Token = token;
        }
        public AuthenticateResponse() { }
    }
}
