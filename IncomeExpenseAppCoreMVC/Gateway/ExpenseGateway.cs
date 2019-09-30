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
            string query = "INSERT INTO Expense(ApprovalStatus,Date,Amount,PaymentType,CheckNo,BankName,Particular)" +
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
                pendingExpense.ApproveStatus = reader["ApprovalStatus"].ToString();
                pendingExpense.BankName = reader["BankName"].ToString();
                pendingExpense.CheckNo = reader["CheckNo"].ToString();
                pendingExpense.Date = (DateTime)reader["Date"];
                pendingExpense.PaymentType = reader["PaymentType"].ToString();
                pendingExpense.Particular = reader["Particular"].ToString();

                pendingList.Add(pendingExpense);
            }

            return pendingList;

        }

        public void PendingApprove(int id)
        {
            string query = "UPDATE Expense SET ApprovalStatus='Yes' Where Id='" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
