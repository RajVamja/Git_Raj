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
    public class CountriesController : Controller
    {
        Icountry countryobj;

        public CountriesController(Icountry consc)
        {
            countryobj = consc;
        }

        public ActionResult GetCountryList(int? ic)
        {
            int pageNumber = ic ?? 1;
            int pageSize = 5;
            return View(countryobj.GetCountryList().ToPagedList(pageNumber, pageSize));
        }


        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(Country country)
        {
            try
            {
                countryobj.AddCountry(country);
                return RedirectToAction("GetCountryList", "Countries");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Editcountry(int? cId)
        {
            try
            {
                var editCountry = countryobj.Editcountry(cId);
                return View(editCountry);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Editcountry(Country co)
        {
            try
            {
                var flag = countryobj.Editcountry(co);
                if (flag == 1)
                {
                    return RedirectToAction("GetCountryList");

                }
                else
                {
                    return RedirectToAction("AddCountry");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult DeleteCountry(int? cId)
        {
            try
            {
                var delCountry = countryobj.DeleteCountry(cId);
                if (delCountry == 1)
                {
                    TempData["countryTrue"] = "Country deleted successfully!";
                }
                else
                {
                    TempData["countryFalse"] = "Country in already exist! You cann't delete it";
                }
                return RedirectToAction("CountryList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}