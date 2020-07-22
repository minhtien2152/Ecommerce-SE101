using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace ECommerce_GUI.Helper
{
    public static class AuthenticatedUser
    {
        public static Account _user;

        public static Account user {
            get {
                return _user;
            }
            set {
                _user = value;
            }
        }
    }
}
