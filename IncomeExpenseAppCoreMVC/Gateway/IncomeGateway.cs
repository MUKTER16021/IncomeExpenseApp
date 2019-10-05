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
      // private string connectionString = @"server=DESKTOP-UKNVMDC\MICROSOFTSQLSERV;database=IncomExpenseDB; integrated security=true;";


        public bool Save(Income income)
        {
            SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
            string query = "INSERT INTO Income(ApprovalStatus,Date,Amount,PaymentType,CheckNo,BankName,Particular)" +
                           "VALUES('" + income.ApproveStatus + "','" + income.Date + "','"+income.Amount+"','"+income.PaymentType+"','"+income.CheckNo+"','"+income.BankName+"','"+income.Particular+"')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowEffect = command.ExecuteNonQuery();
            connection.Close();
            return rowEffect > 0;
        }

        public List<Income> PendingList()
        {
            SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
            string query = "SELECT * FROM Income WHERE ApprovalStatus='No'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Income> pendingList=new List<Income>();
            while (reader.Read())
            {
                Income pendingIncome=new Income();
                pendingIncome.Id = (int)reader["Id"];
                pendingIncome.Amount = (decimal)reader["Amount"];
                pendingIncome.ApproveStatus = reader["ApprovalStatus"].ToString();
                pendingIncome.BankName = reader["BankName"].ToString();
                pendingIncome.CheckNo = reader["CheckNo"].ToString();
                pendingIncome.Date =(DateTime) reader["Date"];
                pendingIncome.PaymentType = reader["PaymentType"].ToString();
                pendingIncome.Particular = reader["Particular"].ToString();
                
                pendingList.Add(pendingIncome);
            }

            return pendingList;

        }

        public bool PendingApprove(List<Income> incomes)
        {
            bool isUpdated = false;
            int row = 0;

            foreach (var incomeId in incomes)
            {
                SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
                string query = "UPDATE Income SET ApprovalStatus='Yes' Where Id='" + incomeId.Id + "'";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                    break;
                }

                connection.Close();
            }

            return isUpdated;
        }

        public List<string> GetYear()
        {
            SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
            string query = "SELECT Date FROM Income";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> yearList = new List<string>();
            while (reader.Read())
            {
                DateTime date = (DateTime)reader["Date"];

                if (yearList.Contains(date.Year.ToString()) != true)
                {
                    yearList.Add(date.Year.ToString());
                }
            }
            return yearList;

        }

        public List<Income> MonthlyReport(string month, string year)
        {
            SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
            string query = "SELECT * FROM Income WHERE ApprovalStatus='Yes'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Income> monthlyReport = new List<Income>();
            while (reader.Read())
            {
                DateTime date = (DateTime)reader["Date"];
                string sMonth = date.Month.ToString();
                string sYear = date.Year.ToString();

                if (sMonth == month && sYear == year)
                {
                    Income MonthlyReportIncome = new Income();
                    MonthlyReportIncome.Id = (int)reader["Id"];
                    MonthlyReportIncome.Date = (DateTime)reader["Date"];
                    MonthlyReportIncome.Amount = (decimal)reader["Amount"];
                    MonthlyReportIncome.BankName = reader["BankName"].ToString();
                    MonthlyReportIncome.CheckNo = reader["CheckNo"].ToString();
                    MonthlyReportIncome.Particular = reader["Particular"].ToString();
                    MonthlyReportIncome.PaymentType = reader["PaymentType"].ToString();

                    monthlyReport.Add(MonthlyReportIncome);
                }
            }

            return monthlyReport;
        }
    }

    
}
