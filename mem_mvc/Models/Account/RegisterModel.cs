using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mem_mvc.Models.Account
{
    public class RegisterModel
    {
        [Display(Name="Full Name:")]
        [Required(ErrorMessage ="Full name is required")]
        public string FullName  { get; set; }

        [Display(Name = "User Name:")]
        [Required(ErrorMessage = "user name is required")]
        public string UserName { get; set; }

        [Display(Name = "Email:")]
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Confirm Email:")]
        [Required(ErrorMessage = "Confirm Email is required")]
        [DataType(DataType.EmailAddress)]
        [Compare(otherProperty: "Email",ErrorMessage =("Emails mismatch"))]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
       // [Compare(otherProperty: "Email", ErrorMessage = ("Emails mismatch"))]
        public string Password { get; set; }

        [Display(Name = "Confirm Password:")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
         [Compare(otherProperty: "Password", ErrorMessage = ("Passwords mismatch"))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Roles:")]
        [Required(ErrorMessage = "Role is required")]
        [UIHint("RolesComboBox")]
        public string Role { get; set; }




    }
}