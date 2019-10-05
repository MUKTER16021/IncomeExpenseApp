using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  IncomeExpenseAppCoreMVC.Gateway;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Manager
{
    
    public class IncomeManager
    {
        private IncomeGateway incomeGateway;

        public IncomeManager()
        {
            incomeGateway = new IncomeGateway();
        }

        public string Save(Income income)
        {
            bool rowEffect = incomeGateway.Save(income);
            if (rowEffect)
            {
                return "Income Save Successfully";
            }

            return "Income Save failded";
        }


        public List<Income> PendingList()
        {
            List<Income> pendingList = incomeGateway.PendingList();

            return pendingList;
        }

        public string UpdateApproveStatus(List<Income> incomes)
        {
            bool isUpdate = incomeGateway.PendingApprove(incomes);
            if (isUpdate)
            {
                return "Approve Successfully done ";
            }

            return "Approve failed ";
        }
        public List<string> GetYearList()
        {
            return incomeGateway.GetYear();
        }

        public List<Income> MonthlyIncome(string month, string year)
        {
            return incomeGateway.MonthlyReport(month, year);
        }
    }
}
