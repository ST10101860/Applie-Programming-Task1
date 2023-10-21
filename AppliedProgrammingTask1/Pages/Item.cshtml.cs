using AppliedProgrammingTask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class ItemModel : PageModel
    {
        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string statement = "";
        public void OnGet()
        {

        }
        public void OnPost(PostAssignedItem onPost) 
        {
            try
            {
                Connection connection = new Connection();
                sqlConnect = new SqlConnection(connection.getConnection);
                sqlConnect.Open();

               statement = "Insert into assign_item values('" + onPost.goodsSelection + "','" + Convert.ToInt32(Request.Query["itemId"]) + "')";
               sqlCommand = new SqlCommand(statement,sqlConnect);
               sqlCommand.ExecuteNonQuery();

               TempData["assignItem"] = "Item of " + onPost.goodsSelection + " is assigned to active disaster.";
               sqlConnect.Close();
            }
            catch
            {
                TempData["assignItem"] = "Kindly sign in first to use this feature.";
            }

        }
    }
}
