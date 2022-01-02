using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectResto.Models.BDD
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            //string datasource = @"localhost\MSSQLLocalDB";
            String datasource = "(LocalDB)\\MSSQLLocalDB";

            //string database = "DATABASE";
            string database = "C:\\USERS\\HP\\DOCUMENTS\\PROJET MONOGAME\\PROJECTRESTO\\MODELS\\DATABASE.MDF";
            string username = "DESKTOP-ATA66B1\\hp";
            string password = "1234";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
