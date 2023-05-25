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
    public class StudentController : Controller
    {
        // GET: Student

        ICountry countryobj;
        IState stateobj;
        ICity cityobj;
        ITeacher teacherchobj;

        public StudentController(ICountry consCountry, IState consState, ICity consCity, ITeacher consTeacher)
        {
            countryobj = consCountry;
            stateobj = consState;
            cityobj = consCity;
            teacherchobj = consTeacher;
        }

        HttpClient client = new HttpClient(); // Receive request from webapi

        public ActionResult StudentIndex(int? pStudent)
        {
            List<SP_studentsDetail_Result> list = new List<SP_studentsDetail_Result>();
            client.BaseAddress = new Uri("http://localhost:61827/api/StudentApi");
            var response = client.GetAsync("StudentApi");
            response.Wait();

            int pagenumber = pStudent ?? 1;
            int pagesize = 5;
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<SP_studentsDetail_Result>>();
                display.Wait();
                list = display.Result;
            }
            return View(list.ToPagedList(pagenumber, pagesize));
        }


        public ActionResult AddStudent()
        {
            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
            ViewBag.TeacherList = new SelectList(teacherchobj.GetTeacherList(), "tId", "fName");
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
        public ActionResult AddStudent(student stu, FormCollection fc)
        {
            string TeacherList = fc["teacher"];
            stu.teacher = TeacherList;
            stu.studentType = Convert.ToInt32(fc["studentTypeE"]);

            client.BaseAddress = new Uri("http://localhost:61827/api/StudentApi");
            var response = client.PostAsJsonAsync<student>("StudentApi", stu);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("StudentIndex");
            }
            return View("AddStudent");
        }


        public ActionResult EditStudent(int stdId, int cId, int sId)
        {
            student stu = null;

            client.BaseAddress = new Uri("http://localhost:61827/api/StudentApi");
            var response = client.GetAsync("StudentApi?stdId=" + stdId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                stu = display.Result;
            }


            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
            ViewBag.StateList = new SelectList(stateobj.GetStateList().Where(a => a.cId == cId), "sId", "sName");
            ViewBag.Citylist = new SelectList(cityobj.GetCityList().Where(a => a.sId == sId), "cityId", "cityName");
            ViewBag.TeacherList = new SelectList(teacherchobj.GetTeacherList(), "tId", "fName");

            return View(stu);
        }


        [HttpPost]
        public ActionResult EditStudent(student stu, FormCollection fc)
        {
            stu.studentType = Convert.ToInt32(fc["studentTypeE"]);

            client.BaseAddress = new Uri("http://localhost:61827/api/StudentApi");
            var response = client.PutAsJsonAsync<student>("StudentApi", stu);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("StudentIndex");
            }
            return View("AddStudent");
        }


        public ActionResult DeleteStudent(int stdId)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/StudentApi");
            var response = client.DeleteAsync("StudentApi?stdId=" + stdId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("StudentIndex");
            }
            return View("AddStudent");
        }
    }
}