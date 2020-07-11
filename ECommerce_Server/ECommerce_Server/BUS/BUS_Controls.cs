using ServerFTM.DAL.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Models;
using System.Diagnostics;

namespace ServerFTM.BUS
{
    class BUS_Controls
    {
        private static BUS_Controls controls;
        public static BUS_Controls Controls
        {
            get
            {
                if (controls == null)
                    controls = new BUS_Controls();
                return controls;
            }
            set => controls = value;
        }

        public bool signup(Account profile)
        {
            profile.UserId = GenerateID();
            profile.SignUpDate = string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now.ToString());
            profile.lastEdit = string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now.ToString());

            Debug.WriteLine(profile.SignUpDate);
            return DAL_Controls.Controls.signUp(profile);
        }

        public Account signin(Account profile)
        {
            Account result = new Account();
            DataTable account = DAL_Controls.Controls.signin(profile);
                
            if (account != null)
            {
                result.UserId = account.Rows[0]["UserId"].ToString();
                result.userName = account.Rows[0]["userName"].ToString();
                result.type = Convert.ToInt32(account.Rows[0]["type"].ToString());
                result.balance = (long)Convert.ToDouble(account.Rows[0]["balance"].ToString());
                result.Name = account.Rows[0]["Name"].ToString();
                result.phoneNum = account.Rows[0]["phoneNum"].ToString();
                result.Address = account.Rows[0]["Address"].ToString();
                result.email = account.Rows[0]["email"].ToString();
            }
            return result;
        }

        string GenerateID()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(10)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
    }
}