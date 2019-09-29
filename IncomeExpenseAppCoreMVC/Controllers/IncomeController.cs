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
        public IActionResult PendingList()
        {
           List<Income> pendingList= incomeManager.PendingList();
           if (pendingList == null)
           {
               ViewBag.Message = "Pending income not found";
           }

           ViewBag.PendingList = pendingList;
           // return View(pendingList);
           return View();
        }
    }
}