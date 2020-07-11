using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFTM.DAL.Query
{
    public class DefineSQLQuery
    {
        public class AccountQuery
        {
            public const string ProcSignUp = "EXECUTE ProcSignUp @UserID , @userName , @password , @type , @SignUpDate , @Name , @phoneNum , @Address , @email , @lastEdit";
            public const string ProcSignIn = "EXECUTE ProcSignIn @userName , @password";
        }
    }
}
