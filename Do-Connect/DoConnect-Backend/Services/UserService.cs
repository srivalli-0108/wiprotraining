using DoConnectBackend.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoConnectBackend.Services
{
    public class UserService : IUserService
    {
        private static readonly List<User> users = new()
        {
            new User { Id = 1, Name = "Srivalli", Email = "srivallip004@gmail.com" , Password = "valli@123" },
            new User { Id = 2, Name = "Asmi", Email = "asmi005@gmail.com" , Password = "asmi@123" },
            
        };
        public User? ValidateUser(string email, string password)
        {
            return users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public List<User> GetAllUsers() => users;

        public User? GetUserById(int id) => users.FirstOrDefault(u => u.Id == id);
    }
}
