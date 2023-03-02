using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{

    public class UsersRepositories
    {

        public int AddUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines("./Users.txt").Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("./Users.txt", userJson + Environment.NewLine);
            return user.UserId;
        }

        public User? Login(User user)
        {
            User data = new User();
            using (StreamReader reader = System.IO.File.OpenText("./Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (currentUser.UserName == user.UserName && currentUser.Password == user.Password)
                        data = currentUser;
                }
            }
            if (data != null)
                return data;
            return null;
        }

        public Boolean Update(User user, int id)
        {
            user.UserId = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("./Users.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (currentUser.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("./Users.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText("./Users.txt", text);
                return true;
            }
                return false;
        }
    }
}
