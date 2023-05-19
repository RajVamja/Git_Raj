using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_343.Repository.Repository
{
   public interface IUser
    {
        bool Login(CustomUserModel u);
        void Signup(CustomUserModel u);

        int countStudents();
        int countTeachers();
        int countSubjects();
        int countCountry();
        int countState();
        int countCity();

    }
}
