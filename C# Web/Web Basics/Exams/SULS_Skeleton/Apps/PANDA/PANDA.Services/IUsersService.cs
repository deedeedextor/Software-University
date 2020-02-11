using PANDA.Models;
using System.Collections;
using System.Collections.Generic;

namespace PANDA.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string password, string email);

        User GetUserByUsernameAndPassword(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
