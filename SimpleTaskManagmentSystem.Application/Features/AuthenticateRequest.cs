using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleTaskManagmentSystem.Application.Features
{
    public class AuthenticateRequest
    {
        public AuthenticateRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public AuthenticateRequest()
        {
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
