using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;
using WebApiRepo_Models.Model;

namespace WebApiRepo_Repository.Repository
{
    public interface IUser
    {
        User Login(CustomUserModel u);
        void Signup(CustomUserModel u);
    }
}
