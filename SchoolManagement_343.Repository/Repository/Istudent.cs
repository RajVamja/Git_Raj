using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement_343.Models.Context;

namespace SchoolManagement_343.Repository.Repository
{
    public interface Istudent
    {
        void AddStudent(student addstd);
        IEnumerable<SP_studentsDetail_Result1> studentDetails();

        student editStudent(int? stdId);

        int editStudent(student editstd);

        int DeleteStudent(int? stdId);
    }
}
