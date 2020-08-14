namespace SimpleTaskManagmentSystem.Infrastructure.Services
{
    using Application.Contracts.Services;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    public class TaskService : ITaskService
    {
        private readonly HttpClient client = WebClient.Instance.client;
        public async System.Threading.Tasks.Task<IEnumerable<Task>> GetTasks()
        {
            IEnumerable<Task> tasks = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync("tasks/getall");
                if (response.IsSuccessStatusCode)
                {
                    tasks = await response.Content.ReadAsAsync<IEnumerable<Task>>();
                }
            }
            catch (Exception ex)
            {

            }

            return tasks;
        }

        public async System.Threading.Tasks.Task<int> Insert(Task task)
        {
            int resultId = 0;
            
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("tasks/insert", task);
                if (response.IsSuccessStatusCode)
                {
                    resultId = await response.Content.ReadAsAsync<int>();
                }
            }
            catch (Exception ex)
            {

            }

            return resultId;
        }

        public async System.Threading.Tasks.Task<bool> Update(Task task)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("tasks/update", task);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {

            }

            return false;
        }
    }
}
