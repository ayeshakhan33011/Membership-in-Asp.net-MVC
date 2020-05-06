
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mem_mvc.Models.Account
{
    public class ChangePasswordModel
    {
        [Display(Name = "Old Password:")]
        [Required(ErrorMessage = "Old Password is required")]
        [DataType(DataType.Password)]
       // [Compare(otherProperty: "Password", ErrorMessage = ("Passwords mismatch"))]
        public String OldPassword { get; set; }

        [Display(Name = "New Password:")]
        [Required(ErrorMessage = "New Password is required")]
        [DataType(DataType.Password)]
        // [Compare(otherProperty: "Password", ErrorMessage = ("Passwords mismatch"))]
        public String NewPassword { get; set; }


        [Display(Name = "Confirm New Password:")]
        [Required(ErrorMessage = "Confirm New Password is required")]
        [DataType(DataType.Password)]
         [Compare(otherProperty: "NewPassword", ErrorMessage = ("Passwords mismatch"))]
        public String ConfirmNewPassword { get; set; }
    }
}