using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProjectResto.Models.BDD
{
    class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            /*
            String source = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = " +
                "C:\\USERS\\HP\\DOCUMENTS\\PROJET MONOGAME\\PROJECTRESTO\\MODELS\\DATABASE.MDF; " +
                "Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            String source1 = "Data Source = " + datasource + "; Initial Catalog = " + database +
            "Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            */
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
