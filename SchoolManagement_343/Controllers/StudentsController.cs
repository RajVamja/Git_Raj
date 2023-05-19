using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using SchoolManagement_343.Helpers.Helper;
using SchoolManagement_343.Models;
using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Models.Model;
using SchoolManagement_343.Repository.Repository;
using SchoolManagement_343.Repository.Services;
using static SchoolManagement_343.FilterConfig;

namespace SchoolManagement_343.Controllers
{
    [SessionEnd]
    public class StudentsController : Controller
    {
        Istudent studentobj;
        Iteacher techobj;
        Icountry countryobj;
        Istate stateobj;
        Icity cityobj;
        Isubject subobj;

        public StudentsController(Istudent consstd ,Iteacher constech, Icountry conscountry, Istate consstate, Icity conscity, Isubject conssub)
        {
            studentobj = consstd;
            techobj = constech;
            countryobj = conscountry;
            stateobj = consstate;
            cityobj = conscity;
            subobj = conssub;
        }
        // GET: Students

        public ActionResult AddStudent()
        {
            try
            {
                student stu = new student();
                //ViewBag.StudentType = from EType g in Enum.GetValues(typeof(EType))
                //                  select new
                //                  {
                //                      ID = (int)g,
                //                      Value = g.ToString()
                //                  };

                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                ViewBag.TeacherList = new SelectList(techobj.GetTeacherList(), "tId", "fName");
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddStudent(student std, FormCollection fc)
         {
            try
            {
                string SubjectList = fc["teacher"];
                std.teacher = SubjectList;
                std.studentType = Convert.ToInt32(fc["studentTypeE"]);

                studentobj.AddStudent(std);
                return RedirectToAction("studentDetails", "Students");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult studentDetails(int? istudent)
        {
            try
            {
                var studentData = studentobj.studentDetails();
                int pageNumber = istudent ?? 1;
                int pageSize = 5;
                return View(studentData.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Error occurred while displaying details: " + ex.Message);
            }
        }



        public ActionResult editStudent(int? stdId, int? cId, int? sId)
        {
            try
            {
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                //ViewBag.StateList = new SelectList(stateobj.GetStateList(), "sId", "sName");
                ViewBag.StateList = new SelectList(stateobj.GetStateList().Where(a => a.cId == cId), "sId", "sName");
                //ViewBag.CityList = new SelectList(cityobj.GetCityList(), "cityId", "cityName");
                ViewBag.CityList = new SelectList(cityobj.GetCityList().Where(a => a.sId == sId), "cityId", "cityName");
                ViewBag.TeacherList = new SelectList(techobj.GetTeacherList(), "tId", "fName");
                //ViewBag.TeacherList = techobj.GetTeacherList();

                //ViewBag.StudentType = from EType g in Enum.GetValues(typeof(EType))
                //                      select new
                //                      {
                //                          ID = (int)g,
                //                          Value = g.ToString()
                //                      }; // For student type list

                var editstu = studentobj.editStudent(stdId);
                return View(editstu);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult editStudent(student student, FormCollection fc)
        {
            try
            {
                //student.studentType = Convert.ToInt32(fc["studentType"]);
                student.studentType = Convert.ToInt32(fc["studentTypeE"]);
                var flag = studentobj.editStudent(student);
                if (flag == 1)
                {
                    return RedirectToAction("studentDetails");

                }
                else
                {
                    return RedirectToAction("AddStudent");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult GetStateList(int cid)
        {
            try
            {
                List<State> selectList = stateobj.GetStateList().Where(a => a.cId == cid).ToList();
                ViewBag.Slist = new SelectList(selectList, "sId", "sName");
                return PartialView("PartialState");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult GetCityList(int sid)
        {
            try
            {
                List<City> selectList = cityobj.GetCityList().Where(a => a.sId == sid).ToList();
                ViewBag.Citylist = new SelectList(selectList, "cityId", "cityName");
                return PartialView("PartialCity");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult DeleteStudent(int? stdId)
        {
            try
            {
                var delstudent = studentobj.DeleteStudent(stdId);
                if (delstudent == 1)
                {
                    TempData["studentTrue"] = "Student deleted successfully!";
                }
                else
                {
                    TempData["studentFalse"] = "Due to some problems student could not deleted!";
                }
                return RedirectToAction("studentDetails");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}