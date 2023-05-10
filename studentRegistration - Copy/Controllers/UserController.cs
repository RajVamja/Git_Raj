using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentRegistration.Models;

namespace studentRegistration.Controllers
{
    public class UserController : Controller
    {
        db_RajVamjaEntities rv = new db_RajVamjaEntities();

        // GET: User
        public ActionResult Index()
        {
            return View(rv.Users.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(customUser user)
        {
            try
            {
                if (rv.Users.Any(a => a.userName == user.userName))
                {
                    ViewBag.Inform = "This Username already exist!";
                    return View();
                }
                else
                {
                    User user1 = new User();
                    user1.fName = user.fName;
                    user1.lName = user.lName;
                    user1.userName = user.userName;
                    user1.passWord = user.passWord;

                    rv.Users.Add(user1);
                    rv.SaveChanges();
                    return RedirectToAction("Login", "User");
                }
            }
            catch (Exception ex)
            {
                return Content("Error occurred while Signing up process!" + ex.Message);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(customUser user)
        {
            var check = rv.Users.Where(a => a.userName.Equals(user.userName) && a.passWord.Equals(user.passWord)).FirstOrDefault();
            if (check != null)
            {
                Session["Id"] = user.uId.ToString();
                Session["uName"] = user.userName.ToString();
                Session["Name"] = check.fName.ToString();
                return RedirectToAction("Show", "student");
            }
            else
            {
                ViewBag.notify = "Invalid username or password!";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }

    }
}