using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Manager;
using Microsoft.AspNetCore.Mvc;
using  IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Controllers
{
    public class IncomeController : Controller
    {
        private IncomeManager incomeManager;
        public IncomeController()
        {
            incomeManager=new IncomeManager();
        }
        [HttpGet]
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Income income)
        {
            income.ApproveStatus = "No";
            string message = incomeManager.Save(income);
            ViewBag.Message = message;
            return View();
        }


        [HttpGet]
        public IActionResult PendingList()
        {
           List<Income> pendingList= incomeManager.PendingList();
           ViewBag.PendingList = pendingList;
           // return View(pendingList);
           return View();
        }

        //[HttpPost]
        //public IActionResult PendingList( Income incomeForApprove)
        //{
        //   incomeManager.UpdateApproveStatus(incomeForApprove.Id);
        //   return RedirectToAction("PendingList");
        //}

        public JsonResult Approve(string[] values)
        {
            List<Income> incomes = new List<Income>();
            foreach (var id in values)
            {
                Income income = new Income();
                income.Id = Convert.ToInt32(id);
                incomes.Add(income);
            }

            string message = incomeManager.UpdateApproveStatus(incomes);

            return Json(message);
        }

        [HttpGet]
        public IActionResult MonthlyIncome()
        {
            ViewBag.YearList = incomeManager.GetYearList();
            return View();
        }

        [HttpPost]
        public IActionResult MonthlyIncome(string month, string year)
        {
            List<Income> monthlyReport = incomeManager.MonthlyIncome(month, year);
            decimal totalIncome = CalculateAmount.Calculate(monthlyReport);
            ViewBag.TotalIncome = totalIncome;
            ViewBag.MonthlyReport = monthlyReport;
            ViewBag.YearList = incomeManager.GetYearList();
            return View();
        }




    }
}