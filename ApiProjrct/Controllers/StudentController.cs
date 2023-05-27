using ApiProjrct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiProjrct.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        HttpClient client = new HttpClient(); // Receive request from webapi
        public ActionResult Index()
        {
            List<SP_StudentsDet_Result> std_list = new List<SP_StudentsDet_Result>();
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.GetAsync("CrudAPI");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<SP_StudentsDet_Result>>();
                display.Wait();
                std_list = display.Result;
            }
            return View(std_list);
        }

        public ActionResult CreateStudent()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "cId", "cName");
            return View();
        }

        public List<Country> GetCountryList()
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();
            List<Country> countries = cs.Countries.ToList();
            return countries;
        }

        [HttpPost]
        public ActionResult CreateStudent(student std)
        {
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.PostAsJsonAsync<student>("CrudAPI", std);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("CreateStudent");
        }


        public ActionResult StudentDetails(int stdId, int cId, int sId)
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();
            student stu = null;
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.GetAsync("CrudAPI?stdId=" + stdId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                stu = display.Result;
            }

            ViewBag.CountryList = new SelectList(GetCountryList(), "cId", "cName");
            List<State> State = cs.States.Where(x => x.cId == cId).ToList();
            ViewBag.StateList = new SelectList(State, "sId", "sName");
            List<City> City = cs.Cities.Where(x => x.sId == sId).ToList();
            ViewBag.CityList = new SelectList(City, "cityId", "cityName");

            return View(stu);
        }

        public ActionResult EditStudent(int stdId, int cId, int sId)
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();
            student stu = null;
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.GetAsync("CrudAPI?stdId=" + stdId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                stu = display.Result;
            }

            // Set ViewBag values for country, state, and city
            ViewBag.CountryList = new SelectList(GetCountryList(), "cId", "cName");
            List<State> State = cs.States.Where(x => x.cId == cId).ToList();
            ViewBag.StateList = new SelectList(State, "sId", "sName");
            List<City> City = cs.Cities.Where(x => x.sId == sId).ToList();
            ViewBag.CityList = new SelectList(City, "cityId", "cityName");

            return View(stu);
        }

        [HttpPost]
        public ActionResult EditStudent(student std)
        {
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.PutAsJsonAsync<student>("CrudAPI", std);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("EditStudent");
        }



        public ActionResult DeleteStu(int stdId, int cId, int sId)
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();
            student stu = null;
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.GetAsync("CrudAPI?stdId=" + stdId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<student>();
                display.Wait();
                stu = display.Result;
            }

            // Set ViewBag values for country, state, and city
            ViewBag.CountryList = new SelectList(GetCountryList(), "cId", "cName");
            List<State> State = cs.States.Where(x => x.cId == cId).ToList();
            ViewBag.StateList = new SelectList(State, "sId", "sName");
            List<City> City = cs.Cities.Where(x => x.sId == sId).ToList();
            ViewBag.CityList = new SelectList(City, "cityId", "cityName");

            return View(stu);
        }

        [HttpPost, ActionName("DeleteStu")]
        public ActionResult DeleteStuConfirm(student std)
        {
            client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
            var response = client.DeleteAsync("CrudAPI?stdId=" + std.stdId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("DeleteStu");
        }
    }
}