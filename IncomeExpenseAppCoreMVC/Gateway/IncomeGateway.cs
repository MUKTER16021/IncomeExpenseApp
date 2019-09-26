using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  System.Data.SqlClient;
using  System.Configuration.Internal;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Gateway
{
    public class IncomeGateway
    {
        private string connectionString = "";

       
        public bool Save(Income income)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Income(ApprovalStatus,Date,Amount,PaymentType,CheckNo,BankName,Particular)" +
                           "VALUES('" + income.ApproveStatus + "','" + income.Date + "','"+income.Amount+"','"+income.PaymentType+"','"+income.CheckNo+"','"+income.BankName+"','"+income.Particular+"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowEffect = command.ExecuteNonQuery();
            connection.Close();
            return rowEffect > 0;
        }
    }

    
}
