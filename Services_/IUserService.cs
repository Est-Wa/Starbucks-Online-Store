using Entities;

namespace Services {
    public interface IUserService {
        Task<int> AddUser(User user);
        Task<User> Login(UserOld user);
        Task<bool> Update(User user, int id);

        Task<User> GetUser(int id);
    }
}