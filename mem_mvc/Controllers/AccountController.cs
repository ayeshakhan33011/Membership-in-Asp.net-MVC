using mem_mvc.Models.Account;
using mem_mvc.Models.general;
using mem_mvc.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace mem_mvc.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet,Authorize(Roles="Administration,Manager")]
        public ActionResult UserList()
        {
            List<UserModel> users = AccountViewModel.GetAllUsers();
            return View(users);

        }



        // GET: Account
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
            bool isAuthenticated=WebSecurity.Login(loginModel.Username,
                    loginModel.Password,loginModel.Rememberme);

                if (isAuthenticated)
                {
                    String returnurl = Request.QueryString["ReturnUrl"];

                    if (returnurl == null)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnurl));
                    }
                   

                }

            }
            else
            {
                ModelState.AddModelError("","uname or password is invalid");
            }
            return View();
        }

        public ActionResult logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }
        [Authorize(Roles="Administration,Manager")]
        [HttpGet]
        public ActionResult Register()
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Administration"))
            {
                ViewBag.RoleId = (int)Role.Administration;

            }
            else
            {
                ViewBag.RoleId = (int)Role.NoRole;
            }

            return View();
        }
         [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "Administration,Manager")]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Administration"))
            {
                ViewBag.RoleId = (int)Role.Administration;

            }
            else
            {
                ViewBag.RoleId = (int)Role.NoRole;
            }

            if (ModelState.IsValid)
            {
                bool isUserExists = WebSecurity.UserExists(registerModel.UserName);
                if (isUserExists)
                {
                    ModelState.AddModelError("UserName", "Username already exists");
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(registerModel.UserName, registerModel.Password,
                        new { FullName = registerModel.FullName, Email = registerModel.Email });
                    Roles.AddUserToRole(registerModel.UserName, registerModel.Role);
                    return RedirectToAction("Index","Dashboard");
                }
            }

            return View();
        }
        [HttpGet,Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, Authorize,ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                bool isPasswordChanged = WebSecurity.ChangePassword(WebSecurity.CurrentUserName,changePasswordModel.OldPassword,changePasswordModel.NewPassword);
                if (isPasswordChanged)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "old password is not correct");
                }
            }


            return View();
        }









    }
}