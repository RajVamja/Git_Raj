using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentRegistration.Models;


namespace studentRegistration.Controllers
{
    public class studentController : Controller
    {
        static IList<student> studentList = new List<student>();

        db_RajVamjaEntities rv = new db_RajVamjaEntities();




        // GET: student
        public ActionResult Show()
        {
            try
            {
                var Data = rv.SP_DiplayStudentDetails().ToList();
                return View(Data);
            }
            catch (Exception ex)
            {
                // display an error message to the user
                return Content("Error occurred while displaying details: " + ex.Message);
            }
        }


        public ActionResult Create()
        {
            ViewBag.CountryList = new SelectList(GetCountryList(), "cid", "cName");

            return View();
        }

        public List<Country> GetCountryList()
        {
            db_RajVamjaEntities cs = new db_RajVamjaEntities();
            List<Country> countries = cs.Countries.ToList();
            return countries;
        }


        [HttpPost]
        public ActionResult Create(student std)
        {
            rv.students.Add(std);
            rv.SaveChanges();
            return RedirectToAction("Show", "student");
        }



        public ActionResult Edit(int Id)
        {
            student editStudent;
            var data = rv.students.Where(e => e.stdId == Id).FirstOrDefault();

            editStudent = new student
            {
                stdId = data.stdId,
                fName = data.fName,
                lName = data.lName,
                DOB = data.DOB,
                sPhone = data.sPhone,
                sEmail = data.sEmail,
                Gender = data.Gender,
                sAddress = data.sAddress,
                city = data.city,
                state = data.state,
                country = data.country
            };
            ViewBag.CountryList = new SelectList(GetCountryList(), "cid", "cName");
            List<State> State = rv.States.Where(x => x.cId == data.country).ToList();
            ViewBag.StateList = new SelectList(State, "sId", "sName");
            List<City> City = rv.Cities.Where(x => x.sId == data.state).ToList();
            ViewBag.CityList = new SelectList(City, "cityId", "cityName");
            TempData["ID"] = Id;
            return View(editStudent);
        }

        [HttpPost]
        public ActionResult Edit(student std)
        {
            int id = Convert.ToInt32(TempData["ID"]);
            student data = rv.students.Where(x => x.stdId == id).FirstOrDefault();

            data.fName = std.fName;
            data.lName = std.lName;
            data.DOB = std.DOB;
            data.sPhone = std.sPhone;
            data.sEmail = std.sEmail;
            data.Gender = std.Gender;
            data.sAddress = std.sAddress;
            data.city = std.city;
            data.state = std.state;
            data.country = std.country;
            rv.SaveChanges();

            return RedirectToAction("Show", "student");

        }

        public ActionResult Delete(int id)
        {
            // Find the student to delete from the database
            var studentToDelete = rv.students.Find(id);

            if (studentToDelete == null)
            {
                return HttpNotFound();
            }

            // Remove the student from the database
            rv.students.Remove(studentToDelete);
            rv.SaveChanges();

            // Remove the student from the in-memory collection
            var student = studentList.FirstOrDefault(s => s.stdId == id);
            if (student != null)
            {
                studentList.Remove(student);
            }

            return RedirectToAction("Show", "student");
        }

        public ActionResult Details(int Id)
        {
            try
            {
                var stdDetail = rv.students.FirstOrDefault(s => s.stdId == Id);
                if (stdDetail == null)
                {
                    return HttpNotFound();
                }
                return View(stdDetail);
            }
            catch (Exception ex)
            {
               
                return Content("Error occurred while retrieving student details: " + ex.Message);
            }
        }
    }
}