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
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Profile()
        {
            var exampleProfile = new ProfileRepository();

            var profile = new ProfileModel
            {
                Name = exampleProfile.GetFirst().Name,
                Username = exampleProfile.GetFirst().Username,
                Age = exampleProfile.GetFirst().Age.Value,
                Gender = exampleProfile.GetFirst().Gender
            };


            return View(profile);
        }
        [HttpPost]
        public ActionResult Register(IndexModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                RegisterRepository.Register(model.Name, model.RegUsername, model.Gender, model.Age, model.RegPassword);
                return RedirectToAction("Profile", "Home");

            }
          
            return View();

        }

      
        [HttpPost]
        public ActionResult LogIn(IndexModel model)
        {
            var userLogging = LogInRepository.LogIn(model.Username, model.Password);

            if (userLogging != null)
            {
                return RedirectToAction("Profile", "Home", new { username = User.Identity.Name });
                TempData["Succes"] = "<script>alert('Welcome!');</script>"; 
            }
            else
            {
                TempData["Error"] = "<script>alert('Wrong username or password!');</script>";
                return View();
            }
        }
       
    }
}
