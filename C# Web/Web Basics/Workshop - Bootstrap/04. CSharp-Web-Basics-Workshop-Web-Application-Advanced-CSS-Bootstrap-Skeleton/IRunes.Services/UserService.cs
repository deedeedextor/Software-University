﻿using IRunes.Data;
using IRunes.Models;
using System.Linq;

namespace IRunes.Services
{
    public class UserService : IUserService
    {
        private readonly RunesDbContext context;

        public UserService(RunesDbContext context)
        {
            this.context = context;
        }

        public User CreateUser(User user)
        {
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();

            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.context.Users
                .SingleOrDefault(user => (user.Username == username || user.Email == username)
                && user.Password == password);
        }
    }
}
