using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Gateway;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Manager
{
    public class BankInfoManager
    {
        private BankInfoGateway bankInfoGateway;

        public BankInfoManager()
        {
            bankInfoGateway=new BankInfoGateway();
        }

        public List<BankInfo> ListOfBank()
        {
            return bankInfoGateway.ListOfBank();
        }
    }
}
