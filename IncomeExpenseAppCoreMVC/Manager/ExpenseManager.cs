using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomeExpenseAppCoreMVC.Manager
{
    public class ExpenseManager
    {
        Gateway.ExpenseGateway expenseGateway = new Gateway.ExpenseGateway();
        //public string save(Models.Expense expense)
        //{
        //    bool rowAffected = expenseGateway.Save(expense);
        //    if (rowAffected)
        //    {
        //        return "Congrates ! your expense, Expensed Successfully";
        //    }
        //    else
        //    {
        //        return "Expensed failled please try Again";
        //    }
        //}


    }
}
