using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class Home_PageModel : PageModel
    {
        public List<Disaster> getClass = new List<Disaster>();
        public string hasData;
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        SqlDataReader sqlData;
        public static string query = "";
        public void OnGet()
        {

            try
            {
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                query = "select* from DISASTER";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                while (sqlData.Read())
                {
                    getClass.Add(new Disaster(Convert.ToInt32(sqlData["DISASTER_ID"].ToString()), sqlData["STARTING_DATE"].ToString(), sqlData["ENDING_DATE"].ToString(), sqlData["LOCATION"].ToString(), sqlData["DISASTER_DESCRIPTION"].ToString(), sqlData["AID"].ToString(), sqlData["NEW_AID"].ToString()));
                }
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
