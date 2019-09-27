using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IncomeExpenseAppCoreMVC.Models;



namespace IncomeExpenseAppCoreMVC.Gateway
{
    public class LoginGateway
    {

        public Login LoginInfo(Login login)
        {
            string connectionString = ConnectionUtility.ConnectionString;
            SqlConnection connection=new SqlConnection(connectionString);

            string query = "SELECT * Registration_tbl WHERE Email='" + login.Email+"',Password='"+login.Password+"'";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
           
            Models.Login loginData=new Login();
            while (reader.Read())
            {
                loginData.Id =(int) reader["Id"];
                loginData.Name = reader["Name"].ToString();
                loginData.Email = reader["Email"].ToString();
                loginData.Password = reader["Password"].ToString();
                loginData.Designation = reader["Designation"].ToString();
            }
            connection.Close();
            return loginData;
        }

    }
}
