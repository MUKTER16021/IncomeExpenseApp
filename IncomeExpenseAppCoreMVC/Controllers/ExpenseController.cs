using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Manager;
using IncomeExpenseAppCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncomeExpenseAppCoreMVC.Controllers
{
    public class ExpenseController : Controller
    {
        private ExpenseManager expenseManager;
        private BankInfoManager bankInfoManager;
        public ExpenseController()
        {
            expenseManager = new ExpenseManager();
            bankInfoManager=new BankInfoManager();
        }
        [HttpGet]
        public IActionResult Save()
        {
            ViewBag.BankList = bankInfoManager.ListOfBank();
            return View();
        }
        [HttpPost]
        public IActionResult Save(Expense expense)
        {
            expense.ApproveStatus = "No";
            string message = expenseManager.Save(expense);
            ViewBag.Message = message;
            ViewBag.BankList = bankInfoManager.ListOfBank();
            return View();
        }


        [HttpGet]
        public IActionResult ExpensePendingList()
        {
            List<Expense> pendingList = expenseManager.PendingList();
            ViewBag.PendingList = pendingList;
            // return View(pendingList);
            return View();
        }

        public JsonResult Approve(string[] values)
        {
            List<Expense> expenses = new List<Expense>();
            foreach (var id in values)
            {
                Expense expense = new Expense();
                expense.Id = Convert.ToInt32(id);
                expenses.Add(expense);
            }

            string message = expenseManager.UpdateApproveStatus(expenses);
            return Json(message);
        }


        [HttpGet]
        public IActionResult MonthlyExpense()
        {
            ViewBag.YearList = expenseManager.GetYearList();
            return View();
        }

        [HttpPost]
        public IActionResult MonthlyExpense(string month, string year)
        {
            List<Expense> monthlyReport = expenseManager.MonthlyIncome(month, year);
            decimal totalExpense = CalculateAmount.Calculate(monthlyReport);
            ViewBag.TotalExpense = totalExpense;
            ViewBag.MonthlyReport = monthlyReport;
            ViewBag.YearList = expenseManager.GetYearList();
            return View();
        }
    }
}