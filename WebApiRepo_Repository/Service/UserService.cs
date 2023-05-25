using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Helpers.Helpers;
using WebApiRepo_Models.Context;
using WebApiRepo_Models.Model;
using WebApiRepo_Repository.Repository;

namespace WebApiRepo_Repository.Service
{
    public class UserService : IUser
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();
        public void Signup(CustomUserModel u)
        {
            rv.Users.Add(UserHelper.convert(u));
            rv.SaveChanges();   
        }


        public User Login(CustomUserModel u)
        {
            var isValid = rv.Users.Where(a => a.userName.Equals(u.userName) && a.passWord.Equals(u.passWord)).FirstOrDefault();
            return (User)isValid;
        }

    }
}
