using PANDA.Data;
using PANDA.Models;
using System.Linq;

namespace PANDA.Services
{
    public class UserService : IUserService
    {
        private readonly PANDAContext context;

        public UserService(PANDAContext context)
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
            return this.context.Users.SingleOrDefault(user => (user.Username == username) && user.Password == password);
        }
    }
}
