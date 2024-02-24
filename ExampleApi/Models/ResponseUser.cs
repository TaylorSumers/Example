using ExampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleApi.Models
{
    public class ResponseUser
    {
        public ResponseUser(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Role = user.Role.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}