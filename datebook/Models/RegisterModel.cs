﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class RegisterModel
    {
        [Display(Name = "Firstname" ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Enter your name")]
        public string Firstname { get; set; }

        [Display(Name = "Username", ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Enter your name")]
        public string Username { get; set; }

         [Display(Name = "Gender", ResourceType = typeof(Register.Register))]
        public string Gender { get; set; }

        [Display(Name = "Age" , ResourceType =  typeof(Register.Register))]
        public int Age { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

        [Display(Name = "PasswordMatch", ResourceType = typeof(Register.Register))]
        [Required(ErrorMessage = "Enter the password again")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Passwords don't match!")]
        public string PasswordMatch { get; set; }

    }
}