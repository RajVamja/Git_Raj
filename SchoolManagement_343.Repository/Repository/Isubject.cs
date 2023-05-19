using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement_343.Models.Context;

namespace SchoolManagement_343.Repository.Repository
{
    public interface Isubject
    {
        IEnumerable<SP_subjectList_Result> SubjectList();
        void AddSubject(Subject addS);

        Subject EditSubject(int? subId);

        int EditSubject(Subject editS);

        int DeleteSubject(int? subId);

    }
}
