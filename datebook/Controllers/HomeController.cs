using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using datebook.Models;
using System.Web.Security;
using Repositories.Repositories;
using System.Web.Script.Serialization;


namespace datebook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchProfile(SearchModel model)
        {
            var user = SearchRepository.Search(model.SearchString);
            if (user != null)
            {
                ViewData["Result"] = user.Username;
                return View();
            }

            else { TempData["Error"] = "<script>alert('No person by that name was found');</script>"; }
            return RedirectToAction("SearchProfile", "Home");
           
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
            var loggedIn = ProfileRepository.GetProfile(User.Identity.Name);

            var model = new ProfileModel();
            model.Username = username;
            model.Name = getProfile.Name;
            model.Age = getProfile.Age.Value;
            model.Gender = getProfile.Gender;
            model.Info = getProfile.Info;
            model.visible = getProfile.Visible.Value;

            ViewBag.CurrentUser = loggedIn.Username;
            ViewBag.Relation = FriendRepository.Relation(loggedIn.UserId, getProfile.UserId);

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
            List<Friends> requestList = FriendRepository.GetRequests(profile.UserId);
            
            ViewBag.Friend = friendList;
            ViewBag.Request = requestList;
            ViewBag.CurrentUser = profile.Username;

            return View();

        }

        public ActionResult AddFriend(string name)
        {
            var friendEntity = new Friends();
            var loggedInProfile = ProfileRepository.GetProfile(User.Identity.Name);
            var friendProfile = ProfileRepository.GetProfile(name);

            friendEntity.Accepted = false;
            friendEntity.UserId = loggedInProfile.UserId;
            friendEntity.FriendId = friendProfile.UserId;


            FriendRepository.AddFriend(friendEntity);

            return RedirectToAction("Profile", "Home");
        }

        public ActionResult AcceptFriend(string userId, string friendId)
        {
            FriendRepository.AcceptFriend(int.Parse(userId), int.Parse(friendId));

            return RedirectToAction("Profile", "Home");
        }
        
        public ActionResult PendingRequests(string username)
        {
            var profile = ProfileRepository.GetProfile(username);
            ViewBag.Request = FriendRepository.GetPending(profile.UserId);

            return PartialView("PendingRequests");
        }

    }
        
}

