using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiRepo_Models.Context;
using PagedList.Mvc;
using PagedList;
using static WebApiRepo.FilterConfig;

namespace WebApiRepo.Controllers
{
    [SessionEnd]
    public class CountryController : Controller
    {
        // GET: Country

        HttpClient client = new HttpClient(); // Receive request from webapi
        public ActionResult CountryIndex(int? pCountry)
        {
            List<Country> list = new List<Country>();
            client.BaseAddress = new Uri("http://localhost:61827/api/CountryApi");
            var response = client.GetAsync("CountryApi");
            response.Wait();

            int pagenumber = pCountry ?? 1;
            int pagesize = 5;
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Country>>();
                display.Wait();
                list = display.Result;
            }
            return View(list.ToPagedList(pagenumber, pagesize));
        }



        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(Country c)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/CountryApi");
            var response = client.PostAsJsonAsync<Country>("CountryApi", c);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CountryIndex");
            }
            return View("AddCountry");
        }


        public ActionResult EditCountry(int cId)
        {
            Country country = null;
            client.BaseAddress = new Uri("http://localhost:61827/api/CountryApi");
            var response = client.GetAsync("CountryApi?cId=" + cId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Country>();
                display.Wait();
                country = display.Result;
            }
            return View(country);
        }   


        [HttpPost]
        public ActionResult EditCountry(Country c)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/CountryApi");
            var response = client.PutAsJsonAsync<Country>("CountryApi", c);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CountryIndex");
            }
            return View("EditCountry");
        }


        public ActionResult DeleteCountry(int cId)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/CountryApi");
            var response = client.DeleteAsync("CountryApi?cId=" + cId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("CountryIndex");
            }
            return View("AddCountry");
        }
    }
}