namespace SimpleTaskManagmentSystem.Infrastructure.Repositories
{
    using Microsoft.Extensions.Options;
    using Npgsql;
    using SimpleTaskManagmentSystem.Application;
    using SimpleTaskManagmentSystem.Application.Contracts.Repositories;
    using SimpleTaskManagmentSystem.Domain.Common;
    using SimpleTaskManagmentSystem.Domain.Models.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class CommentRepository : ICommentRepository
    {
        private readonly AppSettings appSettings;
        public CommentRepository(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        public IEnumerable<Comment> Get(string searchText)
        {
            HashSet<Comment> comments = new HashSet<Comment>();

            var con = new NpgsqlConnection(appSettings.ConnectionString);

            try
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(@"public.""Search_Comment""", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("searchText", searchText);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            comments.Add(new Comment(
                                rdr.GetString(0),
                                rdr.GetInt32(1),
                                rdr.GetDateTime(2),
                                rdr.GetDateTime(3),
                                Enumeration.FromName<CommentType>(rdr.GetString(4))
                                ));
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

            return comments;
        }
    }
}
