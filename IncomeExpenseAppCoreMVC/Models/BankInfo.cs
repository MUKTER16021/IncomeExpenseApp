using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomeExpenseAppCoreMVC.Models
{
    public class BankInfo
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
