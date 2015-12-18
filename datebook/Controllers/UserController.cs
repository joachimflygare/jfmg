using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using datebook.Models;


namespace datebook.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;

        public UserController()
        {

            _userRepository = new UserRepository();

        }

        public ActionResult Index()
        {
            var firstUser = _userRepository.GetFirst();

            var _userModel = new UserModel()
            {
                Name = firstUser.Namn,
                Uid = firstUser.AnvändarID


            };

            return View(_userModel);
        }

    }
}