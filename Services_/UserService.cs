using Entities;
using Repository;

namespace Services
{
    public class UserService : IUserService {

        private readonly IUsersRepositories _userRepository;
        public UserService(IUsersRepositories userRepository) {
            _userRepository = userRepository;
        }
        public async Task<int> AddUser(User user) {
            return await _userRepository.AddUser(user);
        }
        public async Task<User> GetUser(int id)
        {
           return await _userRepository.GetUser(id);
        }
        public async Task<User> Login(User user) {
            return await _userRepository.Login(user);
        }
        public async Task<Boolean> Update(User user, int id) {
            return await _userRepository.Update(user, id);
        }
    }
}