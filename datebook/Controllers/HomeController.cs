using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using datebook.Models;
using System.Web.Security;
using Repositories.Repositories;

namespace datebook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile(string username)
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Index", "Home");
            }

            if (username == null)
            {
                username = User.Identity.Name;
            }

            var getProfile = ProfileRepository.GetProfile(username);
            var model = new ProfileModel();
            model.Username = username;
            model.Name = getProfile.Name;
            model.Age = getProfile.Age.Value;
            model.Gender = getProfile.Gender;
            model.Info = getProfile.Info;
            model.visible = getProfile.Visible.Value;

            return View(model);
        }

        [HttpGet]
        public ActionResult LogIn()
        {

            return View();

        }

        [HttpPost]
        public ActionResult LogIn(LogInModel user)
        {
            if(ModelState.IsValid)
            {
                if(IsValid(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
                }
                else
                {
                    ModelState.AddModelError("", "Invaild Login data");
                }

            }
            return View(user);
        }

        private bool IsValid(string username, string password)
        {
            bool isValid = false;

            using (var db = new MainDbEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    if (user.Passsword == password)
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
               using (var db = new MainDbEntities())
               {
                   var user = db.Users.Create();
                   user.Name = model.Name;
                   user.Username = model.RegUsername;
                   user.Age = model.Age;
                   user.Gender = model.Gender;
                   user.Passsword = model.RegPassword;
                   db.Users.Add(user);
                   db.SaveChanges();
                   return RedirectToAction("Profile", "Home");
               }

            }
            else
            {
                ModelState.AddModelError("", "Incorrect data");
            }

            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Friends()
        {
             if (User.Identity.IsAuthenticated == false) {
                return RedirectToAction("LogIn", "Home");
            }

            var userName = System.Web.HttpContext.Current.User.Identity.Name;
            Users myProfile = ProfileRepository.GetProfile(userName);

            List<Friends> friendList = FriendRepository.GetFriends(myProfile.UserId);
            ViewBag.Profile = friendList;

            return View();
        }

        }
        
       
    }

