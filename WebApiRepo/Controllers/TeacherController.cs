using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using WebApiRepo_Repository.Repository;
using WebApiRepo_Models.Context;
using PagedList.Mvc;
using PagedList;
using static WebApiRepo.FilterConfig;

namespace WebApiRepo.Controllers
{
    [SessionEnd]
    public class TeacherController : Controller
    {
        // GET: Teacher

        ICountry countryobj;
        IState stateobj;
        ICity cityobj;
        ISubject subobj;

        public TeacherController(ICountry consCountry, IState consState, ICity consCity, ISubject consSub)
        {
            countryobj = consCountry;
            stateobj = consState;
            cityobj = consCity;
            subobj = consSub;
        }

        HttpClient client = new HttpClient(); // Receive request from webapi

        public ActionResult TeacherIndex(int? pTeacher)
        {
            List<SP_teachersDetail_Result> list = new List<SP_teachersDetail_Result>();
            client.BaseAddress = new Uri("http://localhost:61827/api/TeacherApi");
            var response = client.GetAsync("TeacherApi");
            response.Wait();

            var test = response.Result;
            int pageNumber = pTeacher ?? 1;
            int pageSize = 5;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<SP_teachersDetail_Result>>();
                display.Wait();
                list = display.Result;
            }
            return View(list.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult AddTeacher()
        {
            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
            ViewBag.SubjectList = new SelectList(subobj.GetSubjectList(), "subId", "subName");
            return View();
        }


        // For state dropdown according to country
        public ActionResult GetStateList(int cId)
        {
            try
            {
                List<State> selectList = stateobj.GetStateList().Where(a => a.cId == cId).ToList();
                ViewBag.Slist = new SelectList(selectList, "sId", "sName");
                return PartialView("PartialState");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        // For city dropdown according to country
        public ActionResult GetCityList(int sId)
        {
            try
            {
                List<City> selectList = cityobj.GetCityList().Where(a => a.sId == sId).ToList();
                ViewBag.Citylist = new SelectList(selectList, "cityId", "cityName");
                return PartialView("PartialCity");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        public ActionResult AddTeacher(teacher teach, FormCollection fc)
        {
            string SubjectList = fc["subjects"];
            teach.subjects = SubjectList;

            client.BaseAddress = new Uri("http://localhost:61827/api/TeacherApi");
            var response = client.PostAsJsonAsync<teacher>("TeacherApi", teach);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("TeacherIndex");
            }
            return View("AddTeacher");
        }


        public ActionResult EditTeacher(int tId, int cId, int sId)
        {
            teacher teach = null;
            client.BaseAddress = new Uri("http://localhost:61827/api/TeacherApi");
            var response = client.GetAsync("TeacherApi?tId=" + tId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<teacher>();
                display.Wait();
                teach = display.Result;
            }

            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
            ViewBag.StateList = new SelectList(stateobj.GetStateList().Where(a => a.cId == cId), "sId", "sName");
            ViewBag.Citylist = new SelectList( cityobj.GetCityList().Where(a => a.sId == sId), "cityId", "cityName");
            ViewBag.SubjectList = new SelectList(subobj.GetSubjectList(), "subId", "subName");

            return View(teach);
        }

        [HttpPost]
        public ActionResult EditTeacher(teacher teach)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/TeacherApi");
            var response = client.PutAsJsonAsync<teacher>("TeacherApi", teach);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("TeacherIndex");
            }
            return View("AddTeacher");
        }
    }
}