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
    public class CityController : Controller
    {
        // GET: City

        ICountry countryobj;
        IState stateobj;

        public CityController(ICountry consCountry, IState consState)
        {
            countryobj = consCountry;
            stateobj = consState;
        }

        HttpClient client = new HttpClient(); // Receive request from webapi

        public ActionResult CityIndex(int? pCity)
        {
            List<SP_cityList_Result> list = new List<SP_cityList_Result>();
            client.BaseAddress = new Uri("http://localhost:61827/api/CityApi");
            var response = client.GetAsync("CityApi");
            response.Wait();

            var test = response.Result;
            int pageNumber = pCity ?? 1;
            int pageSize = 5;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<SP_cityList_Result>>();
                display.Wait();
                list = display.Result;
            }
           
            return View(list.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult AddCity()
        {
            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
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

        [HttpPost]
        public ActionResult AddCity(City city)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/CityApi");
            var response = client.PostAsJsonAsync<City>("CityApi", city);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CityIndex");
            }
            return View("AddCity");
        }



        public ActionResult EditCity(int cityId, int cId)
        {
            City city = null;
            client.BaseAddress = new Uri("http://localhost:61827/api/CityApi");
            var response = client.GetAsync("CityApi?cityId=" + cityId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<City>();
                display.Wait();
                city = display.Result;
            }

            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
            ViewBag.StateList = new SelectList(stateobj.GetStateList().Where(a => a.cId == cId), "sId", "sName");

            return View(city);
        }


        [HttpPost]
        public ActionResult EditCity(City city)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/CityApi");
            var response = client.PutAsJsonAsync<City>("CityApi", city);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CityIndex");
            }
            return View("EditCity");
        }


        public ActionResult DeleteCity(int cityId)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/CityApi");
            var response = client.DeleteAsync("CityApi?cityId=" + cityId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CityIndex");
            }
            return View("AddCity");
        }

        //public ActionResult DeleteStu(int stdId, int cId, int sId)
        //{
        //    RajVamja_webapiEntities cs = new RajVamja_webapiEntities();
        //    student stu = null;
        //    client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
        //    var response = client.GetAsync("CrudAPI?stdId=" + stdId.ToString());
        //    response.Wait();

        //    var test = response.Result;
        //    if (test.IsSuccessStatusCode)
        //    {
        //        var display = test.Content.ReadAsAsync<student>();
        //        display.Wait();
        //        stu = display.Result;
        //    }

        //    // Set ViewBag values for country, state, and city
        //    ViewBag.CountryList = new SelectList(GetCountryList(), "cId", "cName");
        //    List<State> State = cs.States.Where(x => x.cId == cId).ToList();
        //    ViewBag.StateList = new SelectList(State, "sId", "sName");
        //    List<City> City = cs.Cities.Where(x => x.sId == sId).ToList();
        //    ViewBag.CityList = new SelectList(City, "cityId", "cityName");

        //    return View(stu);
        //}

        //[HttpPost, ActionName("DeleteStu")]
        //public ActionResult DeleteStuConfirm(student std)
        //{
        //    client.BaseAddress = new Uri("http://localhost:50954/api/CrudAPI");
        //    var response = client.DeleteAsync("CrudAPI?stdId=" + std.stdId.ToString());
        //    response.Wait();

        //    var test = response.Result;
        //    if (test.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View("DeleteStu");
        //}
    }
}