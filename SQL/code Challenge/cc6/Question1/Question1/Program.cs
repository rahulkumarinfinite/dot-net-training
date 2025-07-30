
using System;
using System.Data;
using System.Data.SqlClient;

namespace Question1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)

        {

              //  Procedure_With_Parameter();
            update();



                Console.Read();
            
        }
        public static SqlConnection getConnection()
        {
            string connect = "Data Source=ICS-LT-B9CBJ84;Initial Catalog=InfiniteDB;" + "user id =sa;password=Ram@rti123456789";;
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }




        public static void Procedure_With_Parameter()
        {
            try
            {
                con = getConnection();
                SqlCommand cmd = new SqlCommand("InsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameters
                cmd.Parameters.AddWithValue("@Name", "Rahul Kumar");
                cmd.Parameters.AddWithValue("@GivenSalary", 50000);
                cmd.Parameters.AddWithValue("@Gender", "Male");

                // Output parameters

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@EmpId";
                param1.DbType = DbType.Int32;
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);



                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@CalculatedSalary";
                param2.DbType = DbType.Decimal;
                param2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param2);




                cmd.ExecuteReader();

                int retcount = (int)cmd.Parameters["@EmpId"].Value;
                decimal retcount1 = (decimal)cmd.Parameters["@CalculatedSalary"].Value;



                Console.WriteLine($"Generated EmpId: {retcount}");
                Console.WriteLine($"Calculated Salary: {retcount1}");

            }

            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }



}



        //Question 2
        public static void update()
        {
            try
            {
                con = getConnection();
                cmd = new SqlCommand("UpdateEmployeeSalary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input parameter
                cmd.Parameters.AddWithValue("@EmpId", 1); // Example EmpId

                // Output parameters

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@UpdatedSalary";
                param1.DbType = DbType.Decimal;
                param1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param1);



                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@Name";
                param2.DbType = DbType.String;
                param2.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param2);


                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@Gender";
                param3.DbType = DbType.String;
           
                param3.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param3);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Updated Employee Details:");
                Console.WriteLine($"EmpId: 1");
                Console.WriteLine($"Name: {param1.Value}");
                Console.WriteLine($"Gender: {param2.Value}");
                Console.WriteLine($"Updated Salary: {param3.Value}");
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
      
}