namespace SimpleTaskManagmentSystem.Infrastructure.Services
{
    using Application.Contracts.Services;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class TaskService : ITaskService
    {
        private readonly HttpClient client = WebClient.Instance.client;
        public async Task<IEnumerable<Domain.Models.Tasks.Task>> GetTasks()
        {
            IEnumerable<Domain.Models.Tasks.Task> tasks = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync("tasks/getall");
                if (response.IsSuccessStatusCode)
                {
                    tasks = await response.Content.ReadAsAsync<IEnumerable<Domain.Models.Tasks.Task>>();
                }
            }
            catch (Exception ex)
            {

            }

            return tasks;
        }
    }
}
