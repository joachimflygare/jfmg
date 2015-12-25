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
                if (LogInRepository.IsValid(model.Username, model.Password))
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
           
            if (ModelState.IsValid && RegisterRepository.CheckUsername(model.Username))
            {
               RegisterRepository.Register(model.Name, model.Username, model.Gender, model.Age, model.Visible, model.Password);
               return RedirectToAction("LogIn", "Home", new { username = User.Identity.Name });
            }

                   else TempData["Error"] = "<script>alert('Error, username already taken');</script>";
                   return RedirectToAction("Register", "Home");
        }

        public ActionResult Edit() 
        {

            return View();
            
        }

        [HttpPost]
        public ActionResult Edit(EditModel model)
        {
            if (EditProfileRepository.EditUser(User.Identity.Name, model.Username, model.Name, model.Gender, model.Age, model.Info, model.Visible, model.Password))
                return RedirectToAction("Profile", "Home", new { username = model.Username });
            else
                TempData["Error"] = "<script>alert('Error, please re-check your input');</script>";
            return RedirectToAction("Edit", "Home");
        }
       
        public ActionResult Friend()
        {
            var profile = ProfileRepository.GetProfile(User.Identity.Name);
            List<Friends> friendList = FriendRepository.GetFriends(profile.UserId);

            ViewBag.Friends = friendList;

            return View();

        }

    }
        
       
    }

