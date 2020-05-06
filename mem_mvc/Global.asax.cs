using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;

namespace mem_mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            InitializeAuthenticationProcess();
        }

        private void InitializeAuthenticationProcess()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("db", "Users", "UserId", "UserName", true);
                //DefaultAccountforadmin
                //WebSecurity.CreateUserAndAccount("admin","admin123");
                //Roles.CreateRole("Administration");
                //Roles.CreateRole("Manager");
                //Roles.CreateRole("User");
              //  Roles.AddUserToRole("admin", "Administration");

            }
        }
    }
}
