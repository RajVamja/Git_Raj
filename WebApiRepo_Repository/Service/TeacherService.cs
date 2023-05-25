using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;
using WebApiRepo_Repository.Repository;

namespace WebApiRepo_Repository.Service
{
    public class TeacherService : ITeacher
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();
        public IEnumerable<teacher> GetTeacherList()
        {
            List<teacher> teachers = rv.teachers.ToList();
            return teachers;
        }
    }
}
