using AppliedProgrammingTask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class MoneyModel : PageModel
    {
        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlReader;
        public static string statement = "";
        public void OnGet()
        {
        }
        public void OnPost(PostAssignMoney onPost)
        {

            try
            {
                Connection connection = new Connection();
               sqlConnect = new SqlConnection(connection.getConnection);
               sqlConnect.Open();

               statement = "Insert into assign_money values('" + Convert.ToDouble(onPost.totalDonation) + "','" + Convert.ToInt32(Request.Query["moneyId"]) + "')";
               sqlCommand = new SqlCommand(statement, sqlConnect);
               sqlCommand.ExecuteNonQuery();

               TempData["assignMoney"] = "total of" + " R" + Convert.ToDouble(onPost.totalDonation) + "  is assigned to active disaster.";
               sqlConnect.Close();
            }
            catch
            {
                TempData["assignMoney"] = "Kindly sign in first to use this feature.";
            }
        }
    }
}
