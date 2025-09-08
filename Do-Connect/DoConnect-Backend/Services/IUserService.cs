using DoConnectBackend.Models;

using System.Collections.Generic;

namespace DoConnectBackend.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User? ValidateUser(string email, string password);

    }
}
