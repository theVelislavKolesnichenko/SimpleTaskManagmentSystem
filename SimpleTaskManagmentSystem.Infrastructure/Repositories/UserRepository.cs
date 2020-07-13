namespace SimpleTaskManagmentSystem.Infrastructure.Repositories
{
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Npgsql;
    using SimpleTaskManagmentSystem.Application;
    using SimpleTaskManagmentSystem.Application.Contracts.Repositories;
    using SimpleTaskManagmentSystem.Application.Features;
    using SimpleTaskManagmentSystem.Domain.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class UserRepository : IUserRepository
    {
        private readonly AppSettings appSettings;

        public UserRepository(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        private User CheckUser(AuthenticateRequest model)
        {
            var con = new NpgsqlConnection(appSettings.ConnectionString);

            try
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(@"public.""Check_User""", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("uname", model.Username);
                    cmd.Parameters.AddWithValue("pword", model.Password);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            return new User(rdr.GetInt32(0),
                                default!,
                                default!,
                                rdr.GetString(1));

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

            return null;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = CheckUser(model);

            return (user == null)
                ? null
                : new AuthenticateResponse(user, generateJwtToken(user));
        }

        public IEnumerable<User> GetAll()
        {
            HashSet<User> user = new HashSet<User>();
            var con = new NpgsqlConnection(appSettings.ConnectionString);

            try
            {
                using (var cmd = new NpgsqlCommand(@"SELECT * FROM ""Users""", con))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            user.Add(new User(rdr.GetInt32(0), 
                                rdr.GetString(1),
                                rdr.GetString(2),
                                rdr.GetString(3)));

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return user;
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
