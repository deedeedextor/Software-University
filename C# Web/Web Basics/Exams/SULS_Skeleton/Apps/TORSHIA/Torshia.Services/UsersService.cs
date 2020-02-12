using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Torshia.Models;
using Totshia.Data;

namespace Torshia.Services
{
    public class UsersService : IUsersService
    {
        private readonly TORSHIAContext db;

        public UsersService(TORSHIAContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Password = this.HashPassword(password),
                Email = email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = this.db.Users
                .SingleOrDefault(u => (u.Username == username) && u.Password == this.HashPassword(password));

            return user;
        }

        public IEnumerable<string> GetUsernames()
        {
            return this.db.Users
                .Select(u => u.Username)
                .ToList();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
