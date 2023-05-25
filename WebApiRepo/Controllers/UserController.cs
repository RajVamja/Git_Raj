using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiRepo_Helpers.Helpers;
using WebApiRepo_Models.Model;
using WebApiRepo_Models.Context;
using WebApiRepo_Repository.Repository;
using WebApiRepo_Repository.Service;
using static WebApiRepo.FilterConfig;

namespace WebApiRepo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        IUser userobj;

        public UserController(IUser consUser)
        {
            userobj = consUser;
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
                userobj.Signup(user);
                return RedirectToAction("Login", "User");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


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
                if (userobj.Login(user) != null)
                {
                    Session["uIdS"] = user.uId.ToString();
                    Session["userNameS"] = user.userName.ToString();
                    Session["fNameS"] = userobj.Login(user).fName;
                    Session["lNameS"] = userobj.Login(user).lName;

                    return RedirectToAction("StudentIndex", "Student");
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
    }
}