using AppliedProgrammingTask1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class AssignedTotalModel : PageModel
    {
        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlReader;
        public static string statement = "";
        public List<GetAssignMoney> getGoods = new List<GetAssignMoney>();
        public void OnGet()
        {
            try
            {
                Connection connection= new Connection();
                sqlConnect = new SqlConnection(connection.getConnection);
                sqlConnect.Open();

                statement = "select*, sum(moneys) as m from assign_money group by asign_id,moneys,disaster_id";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    getGoods.Add(new GetAssignMoney
                    {
                        Id = "MD" + Convert.ToInt32(sqlReader["asign_id"].ToString()),
                        totalDonation = Convert.ToDouble(sqlReader["moneys"].ToString()),
                        tot = Convert.ToDouble(sqlReader["m"].ToString())
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
