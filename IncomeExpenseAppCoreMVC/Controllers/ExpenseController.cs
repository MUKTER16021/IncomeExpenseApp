using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IncomeExpenseAppCoreMVC.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expense(decimal amount,string paymentType,string checkNo,string bankName,DateTime date,string particular,string approvalStatus)
        {

            Models.Expense expense = new Models.Expense();
            expense.Amount = amount;
            expense.PaymentType = paymentType;
            expense.CheckNo = checkNo;
            expense.BankName = bankName;
            expense.Date = date;
            expense.Particular = particular;
            expense.ApproveStatus = approvalStatus;
            return View(expense);
        }
    }
}