using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.PortableExecutable;
using System;
using System.Data.SqlClient;
using AppliedProgrammingTask1.Model;

namespace AppliedProgrammingTask1.Pages
{
    public class Public_ViewModel : PageModel
    {
        public static SqlCommand command;
        public static SqlConnection connect;
        public static SqlDataReader reader;
        public string query = "";
        public static double moneyTotal, goodsPurchase = 0.0;
        public static int goodsCount, disasterCount = 0;

        public List<getPublic> getPublic = new List<getPublic>();
        public void OnGet()
        {
            Connection connection= new Connection();
            connect = new SqlConnection(connection.getConnection);
            connect.Open();
            query = "select sum(AMOUNT) as Amount_Sum from MONEY_";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                moneyTotal = Convert.ToDouble(reader["Amount_Sum"].ToString());
            }
            connect.Close();


            connect = new SqlConnection(connection.getConnection);
            connect.Open();
            query = "select COUNT(*) as amount_sum from GOODS;";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                goodsPurchase = Convert.ToDouble(reader["amount_sum"].ToString());
            }
            connect.Close();

            connect = new SqlConnection(connection.getConnection);
            connect.Open();
            query = "select count(*) as counting from GOODS";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                goodsCount = Convert.ToInt32(reader["counting"].ToString());
            }
            connect.Close();


            connect = new SqlConnection(connection.getConnection);
            connect.Open();
            query = "select count(*) as counting from DISASTER;";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                disasterCount = Convert.ToInt32(reader["counting"].ToString());
            }
            connect.Close();


            connect = new SqlConnection(connection.getConnection);
            connect.Open();
            query = "select d.STARTING_DATE, d.ENDING_DATE,d.DISASTER_DESCRIPTION, d.LOCATION, d.AID, ai.item, am.moneys from DISASTER D inner join LOGINS L on L.LOGIN_ID=D.LOGIN_ID inner join MONEY_ M on M.LOGIN_ID=L.LOGIN_ID inner join assign_item ai on ai.DISASTER_ID=d.DISASTER_ID inner join assign_money am on am.disaster_id=d.DISASTER_ID;";
            command = new SqlCommand(query, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                getPublic.Add(new getPublic {startDate = reader["STARTING_DATE"].ToString(), endDate= reader["ENDING_DATE"].ToString(), description= reader["DISASTER_DESCRIPTION"].ToString(),
                    location= reader["LOCATION"].ToString(), aid= reader["AID"].ToString(), item= reader["item"].ToString(), money= reader["moneys"].ToString()
                });
            }
            connect.Close();


            TempData["goodsPurchase"] = goodsPurchase;
            TempData["goodsCount"] = goodsCount;
            TempData["disasterCount"] = disasterCount;
        }
    }
}
