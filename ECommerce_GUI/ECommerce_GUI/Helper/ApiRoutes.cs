using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_GUI.Helper
{
    public class ApiRoutes
    {
        public const string Base = "api";

        public static class Account
        {
            public const string signup = Base + "/Account/SignUp";
            public const string signin = Base + "/Account/SignIn";
        }
    }
}
