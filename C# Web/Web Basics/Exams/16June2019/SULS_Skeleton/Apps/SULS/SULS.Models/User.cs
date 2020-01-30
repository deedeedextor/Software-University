﻿using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;

namespace SULS.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Submissions = new HashSet<Submission>();
        }

        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Invalid username length!")]
        public string Username { get; set; }

        [RequiredSis]
        public string Email { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, "Invalid password length!")]
        public string Password { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}