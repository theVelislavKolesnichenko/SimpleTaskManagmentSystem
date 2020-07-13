namespace SimpleTaskManagmentSystem.Infrastructure.Services
{
    using Application.Contracts.Services;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class CommentService : ICommentService
    {
        private readonly HttpClient client = WebClient.Instance.client;
        public async Task<IEnumerable<Comment>> GetComments(string searchText)
        {
            IEnumerable<Comment> comments = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync("comments/get?searchText=" + searchText);
                if (response.IsSuccessStatusCode)
                {
                    comments = await response.Content.ReadAsAsync<IEnumerable<Comment>>();
                }
            }
            catch (Exception ex)
            {

            }

            return comments;
        }
    }
}
