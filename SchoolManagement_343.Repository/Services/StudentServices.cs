using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagement_343.Repository.Services
{
    public class StudentServices : Istudent
    {
        RajVamja_schoolmanagement_343Entities rv = new RajVamja_schoolmanagement_343Entities();

        public void AddStudent(student std)
        {
            try
            {
                var existingStudent = rv.students.FirstOrDefault(s => s.fName == std.fName);
                if (existingStudent == null)
                {
                    rv.students.Add(std);
                    rv.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteStudent(int? stdId)
        {
            try
            {
                var delstudent = rv.sp_DeleteStudent(stdId);
                rv.SaveChanges();
                return delstudent;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public student editStudent(int? stdId)
        {
            try
            {
                student stu;
                stu = rv.students.Find(stdId);
                return stu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int editStudent(student student)
        {
            try
            {
                rv.Entry(student).State = System.Data.Entity.EntityState.Modified;
                rv.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SP_studentsDetail_Result1> studentDetails()
        {
            try
            {
                var studentData = rv.SP_studentsDetail().ToList();
                return studentData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
