using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement_343.Helpers.Helper;
using SchoolManagement_343.Models;
using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Models.Model;
using SchoolManagement_343.Repository.Repository;
using SchoolManagement_343.Repository.Services;
using static SchoolManagement_343.FilterConfig;
using PagedList.Mvc;
using PagedList;
using Subject = SchoolManagement_343.Models.Context.Subject;

namespace SchoolManagement_343.Controllers
{
    [SessionEnd]
    public class SubjectsController : Controller
    {

        Isubject subjectobj;

        public SubjectsController(Isubject consS)
        {
            subjectobj = consS;
        }

        // GET: Subjects
        public ActionResult SubjectList(int? isub)
        {
            try
            {
                var subjectdata = subjectobj.SubjectList();
                int pageNumber = isub ?? 1;
                int pageSize = 5;
                return View(subjectdata.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Error occurred while displaying details: " + ex.Message);
            }
        }



        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject subject)
        {
            try
            {
                subjectobj.AddSubject(subject);
                return RedirectToAction("SubjectList", "Subjects");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult EditSubject(int? subId)
        {
            try
            {
                var editsub = subjectobj.EditSubject(subId);
                return View(editsub);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult EditSubject(Subject sub)
        {
            try
            {
                var flag = subjectobj.EditSubject(sub);
                if (flag == 1)
                {
                    return RedirectToAction("SubjectList");

                }
                else
                {
                    return RedirectToAction("AddSubject");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult DeleteSubject(int? subId)
        {
            try
            {
                var delSubject = subjectobj.DeleteSubject(subId);
                if (delSubject == 1)
                {
                    TempData["subjectTrue"] = "Subject deleted successfully!";
                }
                else
                {
                    TempData["subjectFalse"] = "Due to some problems subject could not deleted!";
                }
                return RedirectToAction("SubjectList");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
