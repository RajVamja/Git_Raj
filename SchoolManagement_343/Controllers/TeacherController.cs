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
using PagedList.Mvc;
using PagedList;
using static SchoolManagement_343.FilterConfig;

namespace SchoolManagement_343.Controllers
{
    [SessionEnd]
    public class TeacherController : Controller
    {
        Iteacher techobj;
        Icountry countryobj;
        Istate stateobj;
        Icity cityobj;
        Isubject subobj;

        public TeacherController(Iteacher constech, Icountry conscountry, Istate consstate, Icity conscity, Isubject conssub)
        {
            techobj = constech;
            countryobj = conscountry;
            stateobj = consstate;
            cityobj = conscity;
            subobj = conssub;
        }

        // GET: Teacher

        public ActionResult AddTeacher()
        {
            try
            {
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                ViewBag.SubjectList = new SelectList(subobj.SubjectList(), "subId", "subName");
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddTeacher(teacher tech, FormCollection fc)
        {
            string SubjectList = fc["subjects"];
            tech.subjects = SubjectList;

            techobj.AddTeacher(tech);
            return RedirectToAction("teacherDetails", "Teacher");
        }



        public ActionResult teacherDetails( int? iteacher)
        {
            try
            {
                var teacherData = techobj.teacherDetails();
                int pageNumber = iteacher ?? 1;
                int pageSize = 5;
                return View(teacherData.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Error occurred while displaying details: " + ex.Message);
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

        public ActionResult editTeacher(int? tId, int? cId, int? sId)
        {
            try
            {
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                //ViewBag.StateList = new SelectList(stateobj.GetStateList(), "sId", "sName");
                ViewBag.StateList = new SelectList(stateobj.GetStateList().Where(a => a.cId == cId), "sId", "sName");
                //ViewBag.CityList = new SelectList(cityobj.GetCityList(), "cityId", "cityName");
                ViewBag.CityList = new SelectList(cityobj.GetCityList().Where(a => a.sId == sId), "cityId", "cityName");
                ViewBag.SubjectList = new SelectList(subobj.SubjectList(), "subId", "subName");
                var editteach = techobj.editTeacher(tId);
                return View(editteach);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult editTeacher(teacher teacher)
        {
            try
            {
                var flag = techobj.editTeacher(teacher);
                if (flag == 1)
                {
                    return RedirectToAction("teacherDetails");

                }
                else
                {
                    return RedirectToAction("AddTeacher");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult DeleteTeacher(int? tId)
        {
            try
            {
                var delTeacher = techobj.DeleteTeacher(tId);
                if (delTeacher == 1)
                {
                    TempData["teacherTrue"] = "Teacher deleted successfully!";
                }
                else
                {
                    TempData["teacherFalse"] = "Due to some problems teacher could not deleted!";
                }
                return RedirectToAction("teacherDetails");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}