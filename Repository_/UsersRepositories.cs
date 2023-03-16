using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Repository
{

    public class UsersRepositories : IUsersRepositories
    {
        StoreDbContext _storeDbContext;

        public UsersRepositories(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task<int> AddUser(User user) {

            //change this
            await _storeDbContext.Users.AddAsync(user);
            await _storeDbContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<User> Login(UserOld user) {
            //return null;
            var created = await _storeDbContext.Users.FindAsync(user.UserName);
            return created;
        }

        public async Task<Boolean> Update(User user, int id) {
            var foundUser = await _storeDbContext.Users.FindAsync(id);
            if (foundUser != null)
            {
                _storeDbContext.Entry(foundUser).CurrentValues.SetValues(user);
                await _storeDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
