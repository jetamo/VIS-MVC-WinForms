using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class DBConnector
    {
        public static SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"LAPTOP-AC2BV74K\SQLEXPRESS"; 
            builder.UserID = "admin";         
            builder.Password = "admin"; 
            builder.InitialCatalog = "VIS";
            return builder;
        }
    }
}
