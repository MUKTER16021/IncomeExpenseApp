using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomeExpenseAppCoreMVC.Models
{
    public static class CalculateAmount
    {
        static public decimal Calculate(List<Expense> incomes)
        {
            decimal totalAmount = 0;
            foreach (var amount in incomes)
            {
                totalAmount += amount.Amount;
            }

            return totalAmount;
        }
        static public decimal Calculate(List<Income> incomes)
        {
            decimal totalAmount = 0;
            foreach (var amount in incomes)
            {
                totalAmount += amount.Amount;
            }

            return totalAmount;
        }
    }
}
