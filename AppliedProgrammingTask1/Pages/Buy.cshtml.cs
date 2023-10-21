using AppliedProgrammingTask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class BuyModel : PageModel
    {

        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlReader;
        public static string statement = "";
        public double available, buy, average = 0.0;
        Connection connection= new Connection();
        public void OnGet()
        {
            try
            {
               sqlConnect = new SqlConnection(connection.getConnection);
               sqlConnect.Open();

                statement = "select sum(donated_money) as available from money_details";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    available = Convert.ToDouble(sqlReader["available"].ToString());
                }

                sqlConnect.Close();

                sqlConnect = new SqlConnection(connection.getConnection);
                sqlConnect.Open();

                statement = "select sum(amount) as available from Buy";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    buy = Convert.ToDouble(sqlReader["available"].ToString());
                }
                average = available - buy;
                TempData["available"] = average;
                sqlConnect.Close();
            }
            catch
            {
                TempData["assignedTotal"] = "Kindly sign in first to use this feature.";
            }

        }
        public void OnPost(PostBuy onPost)
        {
            try
            {
               sqlConnect = new SqlConnection(connection.getConnection);
               sqlConnect.Open();

               statement = "Insert into Buy values('" + onPost.goodsSelection + "','" + onPost.totalDonation + "')";
               sqlCommand = new SqlCommand(statement, sqlConnect);
               sqlCommand.ExecuteNonQuery();

                TempData["buy"] = "Item of the name: " + onPost.goodsSelection + " " + "which cost: R" + Convert.ToDouble(onPost.totalDonation) + " " + "will be bought.";
                sqlConnect.Close();
            }
            catch
            {
                TempData["buy"] = "Kindly sign in first to use this feature.";
            }

        }
    }
}
