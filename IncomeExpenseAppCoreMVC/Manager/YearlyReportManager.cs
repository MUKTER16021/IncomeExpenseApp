using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Gateway;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Manager
{
    public class YearlyReportManager
    {
        private IncomeGateway incomeGateway;
        private ExpenseGateway expenseGateway;
        public YearlyReportManager()
        {
            incomeGateway=new IncomeGateway();
            expenseGateway=new ExpenseGateway();
        }

        public List<string> GetYearList()
        {
            List<string> yearList=new List<string>();
            List<string> yearListIncome = incomeGateway.GetYear();
            foreach (var year in yearListIncome)
            {
                if (yearList.Contains(year) != true)
                {
                    yearList.Add(year);
                }
            }
            List<string> yearlistExpense = expenseGateway.GetYear();
            foreach (var year in yearlistExpense)
            {
                if (yearList.Contains(year) != true)
                {
                    yearList.Add(year);
                }
            }

            return yearList;
        }

        public List<Income> MonthlyIncome(string month,string year)
        {
            List<Income> income = incomeGateway.MonthlyReport(month, year);
            return income;
        }
        public List<Expense> MonthlyExpense(string month, string year)
        {
            List<Expense> expenses = expenseGateway.MonthlyReport(month, year);
            return expenses;
        }
    }
}
