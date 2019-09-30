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

        [HttpPost]
        public IActionResult PendingList( Income incomeForApprove)
        {
           incomeManager.UpdateApproveStatus(incomeForApprove.Id);
           return RedirectToAction("PendingList");
        }



    }
}