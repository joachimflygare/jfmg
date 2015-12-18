using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using datebook.Models;
using System.Web.Security;

namespace datebook.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository _userRepository;

        public HomeController()
        {

            _userRepository = new UserRepository();

        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            
            return View();
        }

        public ActionResult Profile()
        {

            return View();
        }


        public ActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
            }
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(IndexModel model)
        {
            var user = IndexRepository.LogIn(model.Username, model.Password);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
            }
            else
            {

                TempData["loginAlert"] = "<script>alert('Wrong username or password!');</script>";
                FormsAuthentication.SignOut();


                return View();
            }
        }


    }
    }
