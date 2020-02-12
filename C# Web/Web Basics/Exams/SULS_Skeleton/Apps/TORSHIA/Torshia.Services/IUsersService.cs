using Torshia.Models;
using System;
using System.Collections.Generic;

namespace Torshia.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string password, string email);

        User GetUserByUsernameAndPassword(string username, string password);

        IEnumerable<string> GetUsernames();
    }
}
