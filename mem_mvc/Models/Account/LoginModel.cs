using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mem_mvc.Models.Account
{
    public class LoginModel
    {
        [Display(Name ="User Name:")]
        [Required (ErrorMessage ="uname is required")]
        public String Username { get; set; }

        [Display(Name = "Password:")]
        [DataType(DataType.Password )]
        public String Password { get; set; }

        [Display(Name = "Remember Me:")]
        public bool Rememberme { get; set; }
    }
}