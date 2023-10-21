using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AppliedProgrammingTask1.Pages
{
    public class Home_PageModel : PageModel
    {
        public double available, buy, average, goods, money = 0.0;
        public List<Disaster> getClass = new List<Disaster>();
        public string hasData;
        public static SqlConnection sqlConnect;
        public static SqlCommand sqlCommand;
        SqlDataReader sqlReader;
        public static string statement = "";
        public void OnGet()
        {

            try
            {
                Connection conn = new Connection();
                sqlConnect = new SqlConnection(conn.getConnection);

                sqlConnect.Open();
                statement = "select* from DISASTER";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    getClass.Add(new Disaster(Convert.ToInt32(sqlReader["DISASTER_ID"].ToString()), sqlReader["STARTING_DATE"].ToString(), sqlReader["ENDING_DATE"].ToString(), sqlReader["LOCATION"].ToString(), sqlReader["DISASTER_DESCRIPTION"].ToString(), sqlReader["AID"].ToString(), sqlReader["NEW_AID"].ToString()));
                }
                sqlConnect.Close();

                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();

                statement = "select sum(AMOUNT) as available from MONEY_";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    available = Convert.ToDouble(sqlReader["available"].ToString());
                }

                sqlConnect.Close();

                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();

                statement = "select sum(amount) as available from Buy";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    buy = Convert.ToDouble(sqlReader["available"].ToString());
                }
                sqlConnect.Close();

                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();

                statement = "select sum(moneys) as available from assign_money";
                sqlCommand = new SqlCommand(statement, sqlConnect);
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    money = Convert.ToDouble(sqlReader["available"].ToString());
                }

                sqlConnect.Close();



                average = available-(money+buy);
                TempData["available"] = average;
            }
            catch
            {
                TempData["DisasterControll"] = "Kindly sign in first to use this feature.";
            }
        }
    }
}
