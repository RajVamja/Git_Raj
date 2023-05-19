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
using static SchoolManagement_343.FilterConfig;

namespace SchoolManagement_343.Controllers
{
    public class UserController : Controller
    {


        IUser userobj;

        public UserController(IUser consu)
        {
            userobj = consu;
        }

        // GET: User
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(CustomUserModel user)
        {
            try
            {
                User udb = UserHelper.convert(user);
                if (userobj.Login(user))
                {
                    Session["uIdS"] = user.uId.ToString();
                    Session["userNameS"] = user.userName.ToString();
                    return RedirectToAction("dashboard", "User");
                }
                else
                {
                    ViewBag.notify = "Invalid username or password!";
                }
                return View("Login");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Signup(CustomUserModel user)
        {
            try
            {
                //User udb = UserHelper.convert(user);

                userobj.Signup(user);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [SessionEnd]
        public ActionResult dashboard()
        {
            try
            {
                ViewBag.Students = userobj.countStudents();
                ViewBag.Teachers = userobj.countTeachers();
                ViewBag.Subjects = userobj.countSubjects();
                ViewBag.Countries = userobj.countCountry();
                ViewBag.States = userobj.countState();
                ViewBag.Cities = userobj.countCity();
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}