using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADLogin.Controllers
{
    public static class Paths
    {
        private static readonly string _loginPath = "~/Login/Index";
        private static readonly string _welcomePath = "~/Home/Welcome";

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