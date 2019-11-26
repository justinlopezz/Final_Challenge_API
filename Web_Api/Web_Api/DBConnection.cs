using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Web_Api
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            //@"Server=myServerAddress;Database=myDatabase;User Id=MyUsername;Password=myPassword;"
            string ConnString = @"Server=tcp:civapi.database.windows.net,1433; database=civapi;User ID=civ_user;Password=Monday1330;";

            return new SqlConnection(ConnString);
        }
    }
}