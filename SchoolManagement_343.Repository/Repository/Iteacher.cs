using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement_343.Models.Context;

namespace SchoolManagement_343.Repository.Repository
{
    public interface Iteacher
    {
        void AddTeacher(teacher addtech);

        IEnumerable<teacher> GetTeacherList();

        IEnumerable<SP_teachersDetail_Result1> teacherDetails();

        teacher editTeacher(int? tId);

        int editTeacher(teacher editT);

        int DeleteTeacher(int? tId);
    }
}
