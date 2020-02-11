using PANDA.Data;
using PANDA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PANDA.Services
{
    public class UsersService : IUsersService
    {
        private readonly PANDAContext db;

        public UsersService(PANDAContext context)
        {
            this.db = context;
        }

        public string CreateUser(string username, string password, string email)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return this.db.Users.SingleOrDefault(user => (user.Username == username) && user.Password == this.HashPassword(password));
        }

        public IEnumerable<string> GetUsernames()
        {
            return this.db.Users.Select(u => u.Username).ToList();
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
