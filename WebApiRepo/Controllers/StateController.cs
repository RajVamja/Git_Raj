using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiRepo_Models.Context;
using WebApiRepo_Repository.Repository;
using PagedList.Mvc;
using PagedList;
using static WebApiRepo.FilterConfig;

namespace WebApiRepo.Controllers
{
    [SessionEnd]
    public class StateController : Controller
    {
        // GET: State

        IState stateobj;
        ICountry countryobj;
        public StateController(IState consstate, ICountry conscountry)
        {
            stateobj = consstate;
            countryobj = conscountry;
        }


        HttpClient client = new HttpClient(); // Receive request from webapi

        public ActionResult StateIndex(int? pState) 
        {
            List<SP_stateList_Result> list = new List<SP_stateList_Result>();
            client.BaseAddress = new Uri("http://localhost:61827/api/StateApi");
            var response = client.GetAsync("StateApi");
            response.Wait();

            var test = response.Result;
            int pagenumber = pState ?? 1;
            int pagesize = 5;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<SP_stateList_Result>>();
                display.Wait();
                list = display.Result;
            }
            return View(list.ToPagedList(pagenumber, pagesize)); 
        }

        public ActionResult AddState()
        {
            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
            return View();
        }
    
        
        [HttpPost]
        public ActionResult AddState(State s)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/StateApi");
            var response = client.PostAsJsonAsync<State>("StateApi", s);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("StateIndex");
            }
            return View("AddState");
        }

        public ActionResult EditState(int sId)
        {
            State state = null;
            client.BaseAddress = new Uri("http://localhost:61827/api/StateApi");
            var response = client.GetAsync("StateApi?sId=" + sId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<State>();
                display.Wait();
                state = display.Result;
            }
            ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");

            return View(state);
        }

        [HttpPost]
        public ActionResult EditState(State s)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/StateApi");
            var response = client.PutAsJsonAsync<State>("StateApi", s);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("StateIndex");
            }
            return View("EditState");
        }


        public ActionResult DeleteState(int sId)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/StateApi");
            var response = client.DeleteAsync("StateApi?sId=" + sId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("StateIndex");
            }
            return View("AddState");
        }
    }
}