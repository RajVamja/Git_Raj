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
    public class SubjectController : Controller
    {
        // GET: Subject
        HttpClient client = new HttpClient(); // Receive request from webapi

        public ActionResult SubjectIndex(int? pSub)
        {
            List<Subject> list = new List<Subject>();
            client.BaseAddress = new Uri("http://localhost:61827/api/SubjectApi");
            var response = client.GetAsync("SubjectApi");
            response.Wait();

            var test = response.Result;
            int pagenumber = pSub ?? 1;
            int pagesize = 5;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Subject>>();
                display.Wait();
                list = display.Result;
            }
            return View(list.ToPagedList(pagenumber, pagesize));
        }


        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject sub)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/SubjectApi");
            var response = client.PostAsJsonAsync<Subject>("SubjectApi", sub);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("SubjectIndex");
            }
            return View("AddSubject");
        }


        public ActionResult EditSubject(int subId)
        {
            Subject sub = null;
            client.BaseAddress = new Uri("http://localhost:61827/api/SubjectApi");
            var response = client.GetAsync("SubjectApi?subId="+ subId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Subject>();
                display.Wait();
                sub = display.Result;
            }
            return View(sub);
        }

        [HttpPost]
        public ActionResult EditSubject(Subject sub)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/SubjectApi");
            var response = client.PutAsJsonAsync<Subject>("SubjectApi", sub);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("SubjectIndex");
            }
            return View("EditSubject");
        }


        public ActionResult DeleteSubject(int subId)
        {
            client.BaseAddress = new Uri("http://localhost:61827/api/SubjectApi");
            var response = client.DeleteAsync("SubjectApi?subId=" + subId.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("SubjectIndex");
            }
            return View("AddSubject");
        }
    }
}