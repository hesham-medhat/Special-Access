using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLogin.Controllers
{
    public static class Paths
    {
        private static string _loginPath = "~/Login/Index";
        private static string _welcomePath = "~/Home/Welcome";

        public static string GetLoginPath()
        {
            return _loginPath;
        }

        public static string GetWelcomePath()
        {
            return _welcomePath;
        }
    }
}