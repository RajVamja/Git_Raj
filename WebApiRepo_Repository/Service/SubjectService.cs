using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;
using WebApiRepo_Repository.Repository;

namespace WebApiRepo_Repository.Service
{
    public class SubjectService : ISubject
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();
        public IEnumerable<Subject> GetSubjectList()
        {
            List<Subject> subjects = rv.Subjects.ToList();
            return subjects;
        }
    }
}
