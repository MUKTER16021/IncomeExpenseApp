using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Gateway;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Manager
{
    public class ExpenseManager
    {
        private ExpenseGateway expenseGateway;
        public ExpenseManager()
        {
            expenseGateway=new ExpenseGateway();
        }
        public string Save(Expense expense)
        {
            bool rowEffect = expenseGateway.Save(expense);
            if (rowEffect)
            {
                return "Income Save Successfully";
            }

            return "Income Save failded";
        }


        public List<Expense> PendingList()
        {
            List<Expense> pendingList = expenseGateway.PendingList();

            return pendingList;
        }

        public void UpdateApproveStatus(int id)
        {
            expenseGateway.PendingApprove(id);
        }


    }
}
