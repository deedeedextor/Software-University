using MUSACA.Data;
using MUSACA.Models;
using System.Linq;

namespace MUSACA.Services
{
    public class UserService : IUserService
    {
        private readonly MUSACAContext context;

        public UserService(MUSACAContext context)
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
