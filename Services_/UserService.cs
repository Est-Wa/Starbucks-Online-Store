using Entities;
using Repository;

namespace Services
{
    public class UserService : IUserService {

        private readonly IUsersRepositories _userRepository;
        //UsersRepositories up = new();

        public UserService(IUsersRepositories userRepository) {
            _userRepository = userRepository;
        }
        public async Task<int> AddUser(User user) {
            PasswordService pw = new PasswordService();
            var result = pw.checkPassword(user.Password);
            if (result < 5)
                return 0;
            return await _userRepository.AddUser(user);
        }
        public async Task<User> Login(UserOld user) {
            return await _userRepository.Login(user);
        }
        public async Task<Boolean> Update(User user, int id) {
            return await _userRepository.Update(user, id);
        }
    }
}