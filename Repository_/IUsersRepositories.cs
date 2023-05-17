using Entities;

namespace Repository {
    public interface IUsersRepositories {
        Task<int> AddUser(User user);
        Task<User> Login(UserOld user);
        Task<bool> Update(User user, int id);

        Task<User> GetUser(int id);
    }
}