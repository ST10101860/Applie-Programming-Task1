using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppliedProgrammingTask1.Pages
{
    public class AdminModel : PageModel
    {
        public bool hasData = false;
        public string email = "";
        public string password = "";
        public static int user_ID;
        public static string userName = "";

        public SqlConnection sqlConnect;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlData;
        public static string query = "";
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            try
            {
                hasData = true;
                email = Request.Form["txtEmail"];
                password = Request.Form["txtPassword"];
                Connection conn = new Connection();
                Hash hash = new Hash();
                sqlConnect = new SqlConnection(conn.getConnection);
                sqlConnect.Open();
                query = "SELECT* FROM admin_login WHERE EMAIL='" + email + "' AND ACCOUNT_PASSWORD='" + password + "'";
                sqlCommand = new SqlCommand(query, sqlConnect);
                sqlData = sqlCommand.ExecuteReader();

                if (sqlData.Read())
                {
                    TempData["admin_login"] = "Welcome   " + sqlData["FIRST_NAME"].ToString() + "   " + sqlData["SECOND_NAME"].ToString() + "  !";
                }
                else
                {
                    TempData["admin_login"] = "We're sorry, but the username or password you entered is incorrect.";
                }
                sqlConnect.Close();
            }
            catch (Exception ex)
            {
                TempData["admin_login"] = ex.ToString();
            }

        }
    }
}
