using SchoolManagement_343.Helpers.Helper;
using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Models.Model;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_343.Repository.Services
{
    public class UserServices : IUser
    {
        RajVamja_schoolmanagement_343Entities rv = new RajVamja_schoolmanagement_343Entities();

        public int countCity()
        {
            return rv.Cities.Count();
        }

        public int countCountry()
        {
            return rv.Countries.Count(); 
        }

        public int countState()
        {
            return rv.States.Count();
        }

        public int countStudents()
        {
            return rv.students.Count();
        }

        public int countSubjects()
        {
            return rv.Subjects.Count();
        }

        public int countTeachers()
        {
            return rv.teachers.Count();
        }

        public bool Login(CustomUserModel u)
        {
            try
            {
                var isValid = rv.Users.Any(a => a.userName.Equals(u.userName) && a.passWord.Equals(u.passWord));
                return isValid;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Signup(CustomUserModel u)
        {
            try
            {
                rv.Users.Add(UserHelper.convert(u));
                rv.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
