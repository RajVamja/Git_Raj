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
    public class StatesController : Controller
    {
        // GET: States
        Istate stateobj;
        Icountry countryobj;
        public StatesController(Istate consstate, Icountry conscountry)
        {
            stateobj = consstate;
            countryobj = conscountry;
        }

        public ActionResult StateList(int? istate)
        {
            try
            {
                var statedata = stateobj.StateList();
                int pageNumber = istate ?? 1;
                int pageSize = 5;
                return View(statedata.ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                return Content("Error occurred while displaying details: " + ex.Message);
            }
        }


        public ActionResult AddState()
        {
            try
            {
                //List<Country> countries = cs.Countries.ToList();
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            try
            {
                stateobj.AddState(state);
                return RedirectToAction("StateList", "States");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult editState(int? sId)
        {
            try
            {
                ViewBag.CountryList = new SelectList(countryobj.GetCountryList(), "cId", "cName");
                var editstate = stateobj.editState(sId);
                return View(editstate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult editState(State state)
        {
            try
            {
                var flag = stateobj.editState(state);
                if (flag == 1)
                {
                    return RedirectToAction("StateList");

                }
                else
                {
                    return RedirectToAction("AddState");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult DeleteState(int? sId)
        {
            try
            {
                var delstate = stateobj.DeleteState(sId);
                if (delstate == 1)
                {
                    TempData["stateTrue"] = "State deleted successfully!";
                }
                else
                {
                    TempData["stateFalse"] = "State in already exist! You cann't delete it";
                }
                return RedirectToAction("StateList");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}