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
        public ActionResult LogIn(LogInModel model)
        {
            if(ModelState.IsValid)
            {
                if (IsValid(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
                }
                else
                {
                    TempData["Error"] = "<script>alert('Login failed, please check your username and password');</script>";
                }

            }
            return View(model);
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

        private bool CheckUsername(string username)
        {
            using (var db = new MainDbEntities())
            {
                var usernameToCheck = db.Users.FirstOrDefault(x => x.Username.Equals(username));

                if (usernameToCheck == null)
                {
                    return true;
                }
                return false;
            }

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
            Boolean boolVis;
            if (ModelState.IsValid)
            {
               using (var db = new MainDbEntities())
               {
                   if (CheckUsername(model.RegUsername))
                   {
                       var user = db.Users.Create();
                       user.Name = model.Name;
                       user.Username = model.RegUsername;
                       user.Age = model.Age;
                       user.Gender = model.Gender;
                       user.Passsword = model.RegPassword;
                       if (model.Visible == 0)
                           boolVis = false;
                       else
                           boolVis = true;
                       user.Visible = boolVis;
                       db.Users.Add(user);
                       db.SaveChanges();
                       return RedirectToAction("LogIn", "Home", new { username = User.Identity.Name });
                   }

                   else TempData["Error"] = "<script>alert('Error, username already taken');</script>";
                   return RedirectToAction("Register", "Home");
               }

            }

            return View();
        }

        public ActionResult Edit() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(EditModel model)
        {
            Boolean boolVis;
                using (var db = new MainDbEntities())
                {
                    var user = db.Users.FirstOrDefault(u => u.Username.Equals(model.Username));

                    if(CheckUsername(model.Username))
                    {
                            
                            user.Name = model.Name;
                            user.Username = model.Username;
                            user.Gender = model.Gender;
                            user.Age = model.Age;
                            user.Info = model.Info;
                            if (model.Visible == 0)
                                boolVis = false;
                            else
                                boolVis = true;
                            user.Visible = boolVis;
                            user.Passsword = model.Password;
                            db.SaveChanges();
                   
                    }
                    else
                    TempData["Error"] = "<script>alert('Error, please check your input');</script>";

                 }
       

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

