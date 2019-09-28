using System.Data.SqlClient;

namespace IncomeExpenseAppCoreMVC.Gateway
{

    public class ExpenseGateway
    { 
        private string connectionString = @"server=DESKTOP-UKNVMDC\MICROSOFTSQLSERV;database=IncomExpenseDB; integrated security=true;";
        SqlConnection connetion = new SqlConnection();
        string query;

        public SqlDataReader Reader;

        public bool Save(Models.Expense expense)
        {
            query = "INSERT INTO Expense(Amount,PaymentType,CheckNo,BankName,Date,particular,ApproveStatus)"+"Values('"+expense.Amount+"','"+expense.PaymentType+"','"+expense.CheckNo+"','"+expense.BankName+"','"+expense.Date+"','"+expense.Particular+"','"+expense.ApproveStatus+"',)";
            SqlCommand command = new SqlCommand();

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected > 0;
        }

    }
}
