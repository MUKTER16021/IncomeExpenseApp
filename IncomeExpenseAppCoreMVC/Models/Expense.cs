using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomeExpenseAppCoreMVC.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public DateTime Date { get; set; }
        public string Particular { get; set; }
        public string ApproveStatus { get; set; }
    }
}
