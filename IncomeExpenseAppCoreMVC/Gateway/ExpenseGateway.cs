using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using  IncomeExpenseAppCoreMVC.Models;

namespace IncomeExpenseAppCoreMVC.Gateway
{

    public class ExpenseGateway {
        SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
        public bool Save(Expense expense)
        {
            string query = "INSERT INTO Expense(ApproveStatus,Date,Amount,PaymentType,CheckNo,BankName,Particular)" +
                           "VALUES('" + expense.ApproveStatus + "','" + expense.Date + "','" + expense.Amount + "','" + expense.PaymentType + "','" + expense.CheckNo + "','" + expense.BankName + "','" + expense.Particular + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowEffect = command.ExecuteNonQuery();
            connection.Close();
            return rowEffect > 0;
        }

        public List<Expense> PendingList()
        {
            string query = "SELECT * FROM Expense WHERE ApproveStatus='No'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Expense> pendingList = new List<Expense>();
            while (reader.Read())
            {
                Expense pendingExpense = new Expense();
                pendingExpense.Id = (int)reader["Id"];
                pendingExpense.Amount = (decimal)reader["Amount"];
                pendingExpense.ApproveStatus = reader["ApproveStatus"].ToString();
                pendingExpense.BankName = reader["BankName"].ToString();
                pendingExpense.CheckNo = reader["CheckNo"].ToString();
                pendingExpense.Date = (DateTime)reader["Date"];
                pendingExpense.PaymentType = reader["PaymentType"].ToString();
                pendingExpense.Particular = reader["Particular"].ToString();

                pendingList.Add(pendingExpense);
            }
            connection.Close();
            return pendingList;

        }

        public bool PendingApprove(List<Expense> expenses)
        {
            bool isUpdated = false;
            int row = 0;

            foreach (var expenseId in expenses)
            {
                string query = "UPDATE Expense SET ApproveStatus='Yes' Where Id='" + expenseId.Id + "'";
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
            string query = "SELECT Date FROM Expense";
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

        public List<Expense> MonthlyReport(string month, string year)
        {
            SqlConnection connection = new SqlConnection(ConnectionUtility.ConnectionString);
            string query = "SELECT * FROM Expense WHERE ApproveStatus='Yes'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Expense> monthlyReport = new List<Expense>();
            while (reader.Read())
            {
                DateTime date = (DateTime)reader["Date"];
                string sMonth = date.Month.ToString();
                string sYear = date.Year.ToString();

                if (sMonth == month && sYear == year)
                {
                    Expense monthlyReportExpense = new Expense();
                    monthlyReportExpense.Id = (int)reader["Id"];
                    monthlyReportExpense.Date = (DateTime)reader["Date"];
                    monthlyReportExpense.Amount = (decimal)reader["Amount"];
                    monthlyReportExpense.BankName = reader["BankName"].ToString();
                    monthlyReportExpense.CheckNo = reader["CheckNo"].ToString();
                    monthlyReportExpense.Particular = reader["Particular"].ToString();
                    monthlyReportExpense.PaymentType = reader["PaymentType"].ToString();

                    monthlyReport.Add(monthlyReportExpense);
                }
            }

            return monthlyReport;
        }
    }
}
