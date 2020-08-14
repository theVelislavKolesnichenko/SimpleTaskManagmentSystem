namespace SimpleTaskManagmentSystem.Infrastructure.Repositories
{
    using Microsoft.Extensions.Options;
    using Npgsql;
    using Application;
    using Application.Contracts.Repositories;
    using Domain.Models.Tasks;
    using System.Collections.Generic;
    using System.Data;
    using System;
    using Type = Domain.Models.Tasks.Type;

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

        public int Insert(Task task)
        {
            var con = new NpgsqlConnection(appSettings.ConnectionString);

            try
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(@"public.""Insert_Tasks""", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("createdDate", task.CreatedDate);
                    cmd.Parameters.AddWithValue("requiredByDate", task.RequiredByDate);
                    cmd.Parameters.AddWithValue("description", task.Description);
                    cmd.Parameters.AddWithValue("status", task.Status);
                    cmd.Parameters.AddWithValue("type", task.Type);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            return rdr.GetInt32(0);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return 0;
        }

        public bool Update(Task task)
        {
            var con = new NpgsqlConnection(appSettings.ConnectionString);

            try
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(@"public.""Update_Tasks""", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("createdDate", task.CreatedDate);
                    cmd.Parameters.AddWithValue("requiredByDate", task.RequiredByDate);
                    cmd.Parameters.AddWithValue("description", task.Description);
                    cmd.Parameters.AddWithValue("status", task.Status);
                    cmd.Parameters.AddWithValue("type", task.Type);

                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return false;
        }
    }
}
