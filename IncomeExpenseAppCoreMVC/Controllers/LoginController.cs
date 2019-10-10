using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IncomeExpenseAppCoreMVC.Manager;
using IncomeExpenseAppCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncomeExpenseAppCoreMVC.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult LoginToFrom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginToFrom(Login login)
        {
            LoginManager loginManage = new LoginManager();
            Login loginInfo = loginManage.LoginInfo(login);
            ViewBag.LoginInfo = loginInfo;
            if (loginInfo.Designation == null)
            {
                ViewBag.Message = "Not match email or password";
                return View();
            }
            else if (loginInfo.Designation == "Jr Accountant")
            {
                return RedirectToAction("Save", "income");
            }
            else if(loginInfo.Designation=="Sr Accountant")
            {
                return RedirectToAction("PendingList", "Income");
            }
            return View();
        }
    }
}