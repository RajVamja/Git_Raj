using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolManagement_343.Repository.Services
{
    public class TeacherServices : Iteacher
    {
        RajVamja_schoolmanagement_343Entities rv = new RajVamja_schoolmanagement_343Entities();
        public void AddTeacher(teacher tech)
        {
            try
            {
                var existingTeacher = rv.teachers.FirstOrDefault(t => t.fName == tech.fName);
                if (existingTeacher == null)
                {
                    rv.teachers.Add(tech);
                    rv.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteTeacher(int? tId)
        {
            try
            {
                var teach = from t in rv.students.ToList() select new { Teachers = t.teacher };
                int flag = 1;
                foreach (var i in teach.ToList())
                {
                    var teacherId = i.Teachers.ToString().Split(',');
                    if (teacherId.Any(x => Convert.ToInt32(x) == tId))
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 0)
                {
                    return 0;
                }
                else
                {
                    teacher TEACHER = rv.teachers.Where(x => x.tId == tId).FirstOrDefault();
                    rv.teachers.Remove(TEACHER);
                    rv.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public teacher editTeacher(int? tId)
        {
            try
            {
                teacher t;
                t = rv.teachers.Find(tId);
                return t;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int editTeacher(teacher teacher)
        {
            try
            {
                rv.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
                rv.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<teacher> GetTeacherList()
        {
            try
            {
                List<teacher> techers = rv.teachers.ToList();
                return techers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SP_teachersDetail_Result1> teacherDetails()
        {
            try
            {
                var teacherData = rv.SP_teachersDetail().ToList();
                return teacherData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
