using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspProj
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class ElectricityBoard
    {
        public void CalculateBill(ElectricityBill eb)
        {
            int units = eb.UnitsConsumed;
            double amount = 0;

            if (units > 1000)
                amount = (units - 1000) * 7.5 + 400 * 5.5 + 300 * 3.5 + 200 * 1.5;
            else if (units > 600)
                amount = (units - 600) * 5.5 + 300 * 3.5 + 200 * 1.5;
            else if (units > 300)
                amount = (units - 300) * 3.5 + 200 * 1.5;
            else if (units > 100)
                amount = (units - 100) * 1.5;
            else
                amount = 0;

            eb.BillAmount = amount;
        }

        public void AddBill(ElectricityBill eb)
        {
            try {
                using (SqlConnection con = DBHandler.GetConnection())
                {
                    string query1 = "SELECT COUNT(*) FROM ElectricityBill WHERE consumer_number=@ID";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.Parameters.AddWithValue("@ID", eb.ConsumerNumber);
                    con.Open();
                    int flag = (int)cmd1.ExecuteScalar();
                    con.Close();
                    if (flag>0)
                        throw new FormatException(" Consumer Number already exists");
                    string query = "INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount) " +
                                   "VALUES (@cn, @name, @units, @amount)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cn", eb.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@name", eb.ConsumerName);
                    cmd.Parameters.AddWithValue("@units", eb.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@amount", eb.BillAmount);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Data Base Error " + e.Message);
            }
            }


        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> list = new List<ElectricityBill>();
            using (SqlConnection con = DBHandler.GetConnection())
            {
                string query = $"SELECT TOP {num} * FROM ElectricityBill ORDER BY consumer_number DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ElectricityBill eb = new ElectricityBill();
                    eb.ConsumerNumber = dr["consumer_number"].ToString();
                    eb.ConsumerName = dr["consumer_name"].ToString();
                    eb.UnitsConsumed = Convert.ToInt32(dr["units_consumed"]);
                    eb.BillAmount = Convert.ToDouble(dr["bill_amount"]);
                    list.Add(eb);
                }
            }
            return list;
        }
    }

}