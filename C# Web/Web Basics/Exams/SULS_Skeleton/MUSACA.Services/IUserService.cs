﻿using MUSACA.Models;

namespace MUSACA.Services
{
    public interface IUserService
    {
        User CreateUser(User user);

        User GetUserByUsernameAndPassword(string username, string password);
    }
}
