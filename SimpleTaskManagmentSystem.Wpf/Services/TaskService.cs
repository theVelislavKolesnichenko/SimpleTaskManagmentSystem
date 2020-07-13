using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskManagmentSystem.Wpf.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient client = WebClient.Instance.client;
        public async Task<IEnumerable<Domain.Models.Tasks.Task>> GetTasks()
        {
            IEnumerable<Domain.Models.Tasks.Task> tasks = null;

            try 
            {
                HttpResponseMessage response = await client.GetAsync("tasks/getAll");
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
