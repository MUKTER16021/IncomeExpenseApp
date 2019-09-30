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
        public ExpenseController()
        {
            expenseManager = new ExpenseManager();
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Expense expense)
        {
            expense.ApproveStatus = "No";
            string message = expenseManager.Save(expense);
            ViewBag.Message = message;
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

        [HttpPost]
        public IActionResult ExpensePendingList(Expense expenseForApprove)
        {
            expenseManager.UpdateApproveStatus(expenseForApprove.Id);
            return RedirectToAction("ExpensePendingList");
        }
    }
}