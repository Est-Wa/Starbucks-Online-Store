using Entities;
using Repository;

namespace Services
{
    public class UserService
    {
        UsersRepositories up = new();
        public int AddUser(User user)
        {
            return up.AddUser(user);
        }
        public User? Login(User user)
        {
            return up.Login(user);
        }
        public Boolean Update(User user, int id)
        {
            return up.Update(user, id);
        }
    }
}