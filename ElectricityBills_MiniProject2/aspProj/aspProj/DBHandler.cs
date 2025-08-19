using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspProj
{
    using System.Configuration;
    using System.Data.SqlClient;

    public class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(conStr);
        }
    }

}