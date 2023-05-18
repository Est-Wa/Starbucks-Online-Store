using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Entities;

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
            await _storeDbContext.Users.AddAsync(user);
            await _storeDbContext.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<User> GetUser(int id)
        {
            User u =  await _storeDbContext.Users.FindAsync(id);
            return u;

        }

        public async Task<User> Login(User user) {
            //return null;
            var created = await _storeDbContext.Users.Where(u=> u.UserName == user.UserName && u.Password == user.Password).ToListAsync();
            return created[0];
        }

        public async Task<Boolean> Update(User user, int id) {
            User foundUser = await _storeDbContext.Users.FindAsync(id);
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
