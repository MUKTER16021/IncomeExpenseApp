using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Manager;
using IncomeExpenseAppCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncomeExpenseAppCoreMVC.Controllers
{
    public class YearlyReportController : Controller
    {
        private YearlyReportManager yearlyReportManager;   
        public YearlyReportController()
        {
            yearlyReportManager=new YearlyReportManager();
        }
       
        [HttpGet]
        public IActionResult YearlyReport()
        {
           List<string>yearList= yearlyReportManager.GetYearList();
           ViewBag.YearList = yearList;
            return View();
        }
        [HttpPost]
        public IActionResult YearlyReport(string year)
        {
            decimal income = 0;
            decimal expense = 0;
            decimal yearlyIncome = 0;
            decimal yearlyExpense = 0;
            decimal januaryExpense = 0;
            decimal februaryExpense = 0;
            decimal marchExpense = 0;
            decimal aprilExpense = 0;
            decimal mayExpense = 0;
            decimal juneExpense = 0;
            decimal julyExpense = 0;
            decimal augustExpense = 0;
            decimal septemberExpense = 0;
            decimal octoberExpense = 0;
            decimal novemberExpense = 0;
            decimal decemberExpense = 0;
            decimal januaryIncome = 0;
            decimal februaryIncome = 0;
            decimal marchIncome = 0;
            decimal aprilIncome = 0;
            decimal mayIncome = 0;
            decimal juneIncome = 0;
            decimal julyIncome = 0;
            decimal augustIncome = 0;
            decimal septemberIncome = 0;
            decimal octoberIncome = 0;
            decimal novemberIncome = 0;
            decimal decemberIncome = 0;

            for (int i = 1; i <= 12; i++)
            {
                if (i == 1)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("1", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.JanuaryIncome = totalmonthlyIncome;
                    januaryIncome = totalmonthlyIncome;
                }
                else if (i == 2)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("2", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.FebruaryIncome = totalmonthlyIncome;
                    februaryIncome = totalmonthlyIncome;
                }
                else if (i == 3)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("3", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.MarchIncome = totalmonthlyIncome;
                    marchIncome = totalmonthlyIncome;
                }
                else if (i == 4)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("4", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.AprilIncome = totalmonthlyIncome;
                    aprilIncome = totalmonthlyIncome;
                }
                else if (i == 5)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("5", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.MayIncome = totalmonthlyIncome;
                    mayIncome = totalmonthlyIncome;
                }
                else if (i == 6)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("6", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.JuneIncome = totalmonthlyIncome;
                    juneIncome = totalmonthlyIncome;
                }
                else if (i == 7)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("7", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.JulyIncome = totalmonthlyIncome;
                    juneIncome = totalmonthlyIncome;
                }
                else if (i == 8)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("8", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.AugustIncome = totalmonthlyIncome;
                    augustIncome = totalmonthlyIncome;
                }
                else if (i == 9)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("9", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.SeptemberIncome = totalmonthlyIncome;
                    septemberIncome = totalmonthlyIncome;
                }
                else if (i == 10)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("10", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.OctoberIncome = totalmonthlyIncome;
                    octoberIncome = totalmonthlyIncome;
                }
                else if (i == 11)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("11", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.NovemberIncome = totalmonthlyIncome;
                    novemberIncome = totalmonthlyIncome;
                }
                else if (i == 12)
                {
                    List<Income> incomes = yearlyReportManager.MonthlyIncome("12", year);
                    decimal totalmonthlyIncome = CalculateAmount.Calculate(incomes);
                    yearlyIncome += totalmonthlyIncome;
                    ViewBag.DecemberIncome = totalmonthlyIncome;
                    decemberIncome = totalmonthlyIncome;
                }
            }

            for (int i = 1; i <= 12; i++)
            {
                if (i == 1)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("1", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.JanuaryExpense = totalMonthlyExpense;
                    januaryExpense = totalMonthlyExpense;
                }
                else if (i == 2)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("2", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.FebruaryExpense = totalMonthlyExpense;
                    februaryExpense = totalMonthlyExpense;
                }
                else if (i == 3)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("3", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.MarchExpense = totalMonthlyExpense;
                    marchExpense = totalMonthlyExpense;
                }
                else if (i == 4)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("4", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.AprilExpense = totalMonthlyExpense;
                    aprilExpense = totalMonthlyExpense;
                }
                else if (i == 5)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("5", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.MayExpense = totalMonthlyExpense;
                    mayExpense = totalMonthlyExpense;
                }
                else if (i == 6)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("6", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.JuneExpense = totalMonthlyExpense;
                    julyExpense = totalMonthlyExpense;
                }
                else if (i == 7)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("7", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.JulyExpense = totalMonthlyExpense;
                    julyExpense = totalMonthlyExpense;
                }
                else if (i == 8)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("8", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.AugustExpense = totalMonthlyExpense;
                    augustExpense = totalMonthlyExpense;
                }
                else if (i == 9)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("9", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.SeptemberExpense = totalMonthlyExpense;
                    septemberExpense = totalMonthlyExpense;
                }
                else if (i == 10)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("10", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.OctoberExpense = totalMonthlyExpense;
                    octoberExpense = totalMonthlyExpense;
                }
                else if (i == 11)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("11", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.NovemberExpense = totalMonthlyExpense;
                    novemberExpense = totalMonthlyExpense;
                }
                else if (i == 12)
                {
                    List<Expense> expenses = yearlyReportManager.MonthlyExpense("12", year);
                    decimal totalMonthlyExpense = CalculateAmount.Calculate(expenses);
                    yearlyExpense += totalMonthlyExpense;
                    ViewBag.DecemberExpense = totalMonthlyExpense;
                    decemberExpense = totalMonthlyExpense;
                }
            }

            ViewBag.JanuaryProfit = januaryIncome - januaryExpense;
            ViewBag.FebruaryProfit = februaryIncome - februaryExpense;
            ViewBag.MarchProfit = marchIncome - marchExpense;
            ViewBag.AprilProfit = aprilIncome - aprilExpense;
            ViewBag.MayProfit = mayIncome - mayExpense;
            ViewBag.JuneProfit = juneIncome - julyExpense;
            ViewBag.JulyProfit = julyIncome - julyExpense;
            ViewBag.AugustProfit = augustIncome - augustExpense;
            ViewBag.SeptemberProfit = septemberIncome - septemberExpense;
            ViewBag.OctoberProfit = octoberIncome - octoberExpense;
            ViewBag.NovemberProfit = novemberIncome - novemberExpense;
            ViewBag.DecemberProfit = decemberIncome - decemberExpense;

           
            ViewBag.YearlyIncome = yearlyIncome;
            ViewBag.YearlyExpense = yearlyExpense;
            ViewBag.YearlyProfit = yearlyIncome - yearlyExpense;
            List<string> yearList = yearlyReportManager.GetYearList();
            ViewBag.YearList = yearList;
            return View();
        }
    }
}