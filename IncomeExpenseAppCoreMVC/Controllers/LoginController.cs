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

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult LoginToFrom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult loginToFrom(Login login)
        {
            LoginManager loginManage = new LoginManager();
            Login loginInfo = loginManage.LoginInfo(login);
            ViewBag.LoginInfo = loginInfo;
            return View();
        }
    }
}