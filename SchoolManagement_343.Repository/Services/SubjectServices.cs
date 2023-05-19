using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SchoolManagement_343.Repository.Services
{
    public class SubjectServices : Isubject
    {
        RajVamja_schoolmanagement_343Entities cs = new RajVamja_schoolmanagement_343Entities();

        public void AddSubject(Subject subject)
        {

            try
            {
                var existingSubject = cs.Subjects.FirstOrDefault(s => s.subName == subject.subName);
                if (existingSubject == null)
                {
                    // country already exists, return an error or redirect to a different action
                    cs.Subjects.Add(subject);
                    cs.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int DeleteSubject(int? subId)
        {
            try
            {
                var subj = from s in cs.teachers.ToList() select new { Subjects = s.subjects };
                int flag = 1;
                foreach (var i in subj.ToList())
                {
                    var subjectId = i.Subjects.ToString().Split(',');
                    if (subjectId.Any(x => Convert.ToInt32(x) == subId))
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
                    Subject SUBJECT = cs.Subjects.Where(x => x.subId == subId).FirstOrDefault();
                    cs.Subjects.Remove(SUBJECT);
                    cs.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Subject EditSubject(int? subId)
        {
            try
            {
                Subject s;
                s = cs.Subjects.Find(subId);
                return s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int EditSubject(Subject sub)
        {
            try
            {
                cs.Entry(sub).State = System.Data.Entity.EntityState.Modified;
                cs.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public IEnumerable<SP_subjectList_Result> SubjectList()
        {
            try
            {
                var subjectdata = cs.SP_subjectList().ToList();
                return subjectdata;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
