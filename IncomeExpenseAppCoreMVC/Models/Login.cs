﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomeExpenseAppCoreMVC.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  string Designation { get; set; }
    }
}
