using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PasswordService:IPasswordService
    {
        public int checkPassword(string pw)
        {
            return Zxcvbn.Core.EvaluatePassword(pw).Score;
        }
    }
}
