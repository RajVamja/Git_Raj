using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;
using WebApiRepo_Models.Model;

namespace WebApiRepo_Helpers.Helpers
{
    public class UserHelper
    {
        public static User convert(CustomUserModel cu)
        {
            User u = new User();
            u.uId = cu.uId;
            u.fName = cu.fName;
            u.lName = cu.lName;
            u.userName = cu.userName;
            u.passWord = cu.passWord;
            return u;
        }
    }
}
