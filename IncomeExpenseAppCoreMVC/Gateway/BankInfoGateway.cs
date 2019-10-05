using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Gateway
{
    public class BankInfoGateway
    {
        SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
        public List<BankInfo> ListOfBank()
        {
            string query = "SELECT * FROM BankInfo";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BankInfo> bankList = new List<BankInfo>();
            while (reader.Read())
            {
                BankInfo bank = new BankInfo();
                bank.Id = (int)reader["Id"];
                bank.BankName = reader["BankName"].ToString();
                bank.AccountNumber = reader["AccountNumber"].ToString();
                bank.CurrentBalance = (decimal)reader["CurrentBalance"];

                bankList.Add(bank);
            }
            connection.Close();
            return bankList;
        }
    }
}
