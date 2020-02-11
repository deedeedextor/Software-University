using System;
using System.Collections.Generic;
using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reports = new HashSet<Report>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public RoleStatus Role { get; set; }

        public virtual ICollection<Report> Reports{ get; set; }
    }
}