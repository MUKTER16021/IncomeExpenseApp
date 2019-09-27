using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Gateway;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Manager
{
    public class LoginManager
    {
        private LoginGateway loginGateway;
        public LoginManager()
        {
            loginGateway=new LoginGateway();
        }

        public Login LoginInfo(Login login)
        {
            Login loginInfo = loginGateway.LoginInfo(login);
            return loginInfo;
        }
    }
}
