using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace mem_mvc.Models.general
{
    public class AppSetting
    {
        public static String ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        }
    }
}