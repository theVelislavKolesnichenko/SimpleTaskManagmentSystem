namespace SimpleTaskManagmentSystem.Infrastructure.Repositories
{
    using Microsoft.Extensions.Options;
    using Npgsql;
    using Application;
    using Application.Contracts.Repositories;
    using Domain.Models.Tasks;
    using System.Collections.Generic;
    using System.Data;

    public class TaskRepository : ITaskRepository
    {
        private readonly AppSettings appSettings;
        public TaskRepository(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        public IEnumerable<Task> GetTasks()
        {
            HashSet<Task> tasks = new HashSet<Task>();
            var con = new NpgsqlConnection(appSettings.ConnectionString);

            try
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(@"public.""Select_Tasks""", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var task = new Task(
                                rdr.GetInt32(0),
                                rdr.GetDateTime(1),
                                rdr.GetDateTime(2),
                                rdr.GetString(3),
                                Status.FromName<Status>(rdr.GetString(4)),
                                Type.FromName<Type>(rdr.GetString(5)));

                            tasks.Add(task);

                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return tasks;
        }
    }
}
