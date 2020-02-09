using System;
using System.ComponentModel.DataAnnotations;

namespace PANDA.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}