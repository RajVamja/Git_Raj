using Newtonsoft.Json;
using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static SchoolManagement_343.FilterConfig;
using PagedList.Mvc;
using PagedList;

namespace SchoolManagement_343.Controllers
{
    [SessionEnd]
    public class CitiesController : Controller
    {

        Icity cityobj;
        Istate stateobj;
        Icountry countryobj;

        public CitiesController(Icity conscity, Istate consstate, Icountry conscountry)
        {
            cityobj = conscity;
            stateobj = consstate;
            countryobj = conscountry;
        }


        // GET: Cities
        public ActionResult CityList(int? icity)
        {
            try
            {
                var citydata = cityobj.CityList().ToList();
                int pageNumber = icity ?? 1;
                int pageSize = 5;
                return View(citydata.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Error occurred while displaying details: " + ex.Message);
            }
        }


        public ActionResult AddCity()
        {
            try
            {
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddCity(City city)
        {
            try
            {
                cityobj.AddCity(city);
                return RedirectToAction("CityList", "Cities");
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

        public ActionResult editCity(int? cityId, int? cId)
        {
            try
            {
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                ViewBag.StateList = new SelectList(stateobj.GetStateList().Where(a => a.cId == cId), "sId", "sName");
                var editc = cityobj.editCity(cityId);
                return View(editc);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult editCity(City city)
        {
            try
            {
                var flag = cityobj.editCity(city);
                if (flag == 1)
                {
                    return RedirectToAction("CityList");

                }
                else
                {
                    return RedirectToAction("AddCity");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult DeleteCity(int? cityId)
        {
            try
            {
                var del = cityobj.DeleteCity(cityId);
                if (del == 1)
                {
                    TempData["cityTrue"] = "City deleted successfully!";
                }
                else
                {
                    TempData["cityFalse"] = "City in already exist! You cann't delete it";
                }
                return RedirectToAction("CityList");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}