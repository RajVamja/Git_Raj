using studentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentRegistration.Controllers;

namespace studentRegistration.Controllers
{
    public class country_state_cityController : Controller
    {
        db_RajVamjaEntities cs = new db_RajVamjaEntities();

        // GET: country_state_city
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowCountries()
        {
            var countries = cs.Countries.ToList();
            return View(countries);
        }

        public ActionResult AddCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCountry(Country country)
        {
            var existingCountry = cs.Countries.FirstOrDefault(c => c.cName == country.cName);
            if (existingCountry != null)
            {
                // country already exists, return an error or redirect to a different action
                return Content("Error occurred while adding the country");
            }

            // country doesn't exist, add it to the table and redirect to the list view
            cs.Countries.Add(country);
            cs.SaveChanges();
            return RedirectToAction("ShowCountries");
        }


        public ActionResult ShowStates()
        {
            var states = cs.States.ToList();
            return View(states);
        }

        public ActionResult AddState()
        {
            countriesController controller = new countriesController();
            ViewBag.CountryList = new SelectList(controller.GetCountryList(), "cid", "cName");
            return View();
        }

        [HttpPost]
        public ActionResult AddState(State state)
        {
            var existingState = cs.States.FirstOrDefault(c => c.sName == state.sName);
            if (existingState != null)
            {
                // country already exists, return an error or redirect to a different action
                return Content("Error occurred while adding the state");
            }

            // country doesn't exist, add it to the table and redirect to the list view
            cs.States.Add(state);
            cs.SaveChanges();
            return RedirectToAction("ShowStates");
        }



        public ActionResult ShowCities()
        {
            var cities = cs.Cities.ToList();
            return View(cities);
        }


        public ActionResult AddCity()
        {
            countriesController controller = new countriesController();
            ViewBag.CountryList = new SelectList(controller.GetCountryList(), "cid", "cName");
            return View();
        }

        [HttpPost]
        public ActionResult AddCity(City city)
        {
            var existingCity = cs.Cities.FirstOrDefault(c => c.cityName == city.cityName);
            if (existingCity != null)
            {
                // country already exists, return an error or redirect to a different action
                return Content("Error occurred while adding the city");
            }

            // country doesn't exist, add it to the table and redirect to the list view
            cs.Cities.Add(city);
            cs.SaveChanges();
            return RedirectToAction("ShowCities");
        }



        // Delete City

        public ActionResult DeleteCity(int? cityId)
        {
            try
            {
                var delCity = cs.Cities.FirstOrDefault(c => c.cityId == cityId);
                if (delCity != null)
                {
                    cs.sp_DeleteCity(cityId);
                    return RedirectToAction("ShowCities");
                }
                else
                {
                    return Content("Due to some resons city could not found");
                }
            }
            catch (Exception ex)
            {
                return Content("Error occurred while deleting the particular city: " + ex.Message);
            }
        }


        // Delete State
        public ActionResult DeleteState(int? sId)
        {
            try
            {
                var delState = cs.States.FirstOrDefault(c => c.sId == sId);
                if (delState != null)
                {
                    cs.sp_DeleteState(sId);
                    return RedirectToAction("ShowStates");
                }
                else
                {
                    return Content("Due to some resons state could not found");
                }
            }
            catch (Exception ex)
            {
                return Content("Error occurred while deleting the particular state: " + ex.Message);
            }
        }


        // Delete Country
        public ActionResult DeleteCountry(int? cId)
        {
            try
            {
                var delCountry = cs.Countries.FirstOrDefault(c => c.cId == cId);
                if (delCountry != null)
                {
                    cs.sp_DeleteCountry(cId);
                    return RedirectToAction("ShowCountries");
                }
                else
                {
                    return Content("Due to some resons ciuntry could not found");
                }
            }
            catch (Exception ex)
            {
                return Content("Error occurred while deleting the particular country: " + ex.Message);
            }
        }


        // Edit Country
        public ActionResult EditCountry(int? cId)
        {
            Country editCountry;
            var data = cs.Countries.Where(e => e.cId == cId).FirstOrDefault();

            editCountry = new Country
            {
                cName = data.cName
            };
            TempData["ID"] = cId;
            return View(editCountry);
        }

        [HttpPost]
        public ActionResult EditCountry(Country cnt)
        {
            int id = Convert.ToInt32(TempData["ID"]);
            Country data = cs.Countries.Where(x => x.cId == id).FirstOrDefault();

            data.cName = cnt.cName;
            cs.SaveChanges();

            return RedirectToAction("ShowCountries", "country_state_city");
        }



        // Edit State
        public ActionResult EditState(int? sId)
        {
            State editState;
            var data = cs.States.Where(e => e.sId == sId).FirstOrDefault();

            editState = new State
            {
                cId = data.cId,
                sName = data.sName
                
            };
            countriesController controller = new countriesController();
            ViewBag.CountryList = new SelectList(controller.GetCountryList(), "cid", "cName");
            TempData["ID"] = sId;
            return View(editState);
        }

        [HttpPost]
        public ActionResult EditState(State sts)
        {
            int id = Convert.ToInt32(TempData["ID"]);
            State data = cs.States.Where(x => x.sId == id).FirstOrDefault();

            data.cId = sts.cId;
            data.sName = sts.sName;
            cs.SaveChanges();

            return RedirectToAction("ShowStates", "country_state_city");
        }


        // Edit City
        public ActionResult EditCity(int? cityId)
        {
            City editCity;
            var data = cs.Cities.Where(e => e.cityId == cityId).FirstOrDefault();

            editCity = new City
            {
                cId = data.cId,
                sId = data.sId,
                cityName = data.cityName
            };
            countriesController controller = new countriesController();
            ViewBag.CountryList = new SelectList(controller.GetCountryList(), "cid", "cName");
            List<State> State = cs.States.Where(x => x.cId == data.cId).ToList();
            ViewBag.StateList = new SelectList(State, "sId", "sName");
            TempData["ID"] = cityId;
            return View(editCity);
        }

        [HttpPost]
        public ActionResult EditCity(City ct)
        {
            int id = Convert.ToInt32(TempData["ID"]);
            City data = cs.Cities.Where(x => x.cityId == id).FirstOrDefault();

            data.cId = ct.cId;
            data.sId = ct.sId;
            data.cityName = ct.cityName;
            cs.SaveChanges();

            return RedirectToAction("ShowCities", "country_state_city");
        }
    }
}

