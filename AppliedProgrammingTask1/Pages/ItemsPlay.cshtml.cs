using AppliedProgrammingTask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class ItemsPlayModel : PageModel
    {
        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlReader;
        public static string statement = "";
        public List<GetAssignedItem> getGoods = new List<GetAssignedItem>();
        public void OnGet()
        {
            try
            {
                Connection connection = new Connection();
                sqlConnect = new SqlConnection(connection.getConnection);
                sqlConnect.Open();

                statement = "select* from assign_item";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    getGoods.Add(new GetAssignedItem
                    {
                        Id = "GD" + Convert.ToInt32(sqlReader["asign_id"].ToString()),
                        goodsSelection = sqlReader["item"].ToString()
                    });
                }

                sqlConnect.Close();
            }
            catch
            {
                TempData["assignedTotal"] = "Kindly sign in first to use this feature.";
            }
        }
    }
}
