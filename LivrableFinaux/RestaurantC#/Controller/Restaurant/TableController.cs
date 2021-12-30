using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectResto.Controllers.Restaurant
{
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.BDD;
    class TableController
    {
        public static List<Table> tables;
        public SqlConnection connection;

        public TableController()
        {
            tables = new List<Table>();
            connection = DBUtils.GetDBConnection();
        }

        public int NumberOfTableWhoAreFree()
        {
            int number = 0;
            foreach (Table table in tables.ToArray())
            {
                if (table.PlaceDisponible > 0)
                {
                    number++;
                }
            }

            return number;
        }
        
        public List<Table> TableWhoAreFree()
        {
            List<Table> t = new List<Table>();
            foreach (Table table in tables.ToArray())
            {
                if (table.PlaceDisponible > 0)
                {
                    t.Add(table);
                }
            }

            return t;
        }

        public String GetScript()
        {
            StringBuilder script = new StringBuilder();

            script.AppendLine("CREATE TABLE Table");
            script.AppendLine("(");
            script.AppendLine("\t id Int Auto_increment  NOT NULL ,");
            script.AppendLine("placeTotal  Int NOT NULL ,");
            script.AppendLine("placeDisponible  Int NOT NULL ,");
            script.AppendLine("isFree Varchar (50) NOT NULL ,");
            script.AppendLine(",CONSTRAINT Table_PK PRIMARY KEY (id)");
            script.AppendLine(")ENGINE=InnoDB;");

            return script.ToString();
        }


        public void CreateTable()

        {
            try
            {
                connection.Open();

                String sql = GetScript();

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Closez la connexion.
                connection.Close();
                // Éliminez l'objet, libérant les ressources.
                connection.Dispose();
            }
        }

        public void AddTable(Table Table)
        {
            tables.Add(Table);
        }

        public void DeleteTable(Table Table)
        {
            tables.Remove(Table);
        }

        public void UpdateTable(Table Table)
        {
            tables.Remove(Table);
            tables.Add(Table);
        }

        public void All()
        {
            try
            {
                connection.Open();

                QueryTable(connection);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Closez la connexion.
                connection.Close();
                // Éliminez l'objet, libérant les ressources.
                connection.Dispose();
            }
        }

        private void QueryTable(SqlConnection conn)
        {
            string sql = "Select id, placeTotal, placeDisponible, isFree from Table";
            // Créez un objet Command.
            SqlCommand cmd = new SqlCommand();

            // Combinez l'objet Command avec Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Récupérez l'index de Column id dans l'instruction de requête SQL.
                        //int TableIdIndex = reader.GetOrdinal("id"); // 0
                        long TableId = Convert.ToInt64(reader.GetValue(0));

                        // Récupérez l'index de Column placeTotal dans l'instruction de requête SQL.
                        int TablePlaceTotalIndex = reader.GetOrdinal("placeTotal");// 2
                        long TablePlaceTotal = Convert.ToInt64(reader.GetValue(TablePlaceTotalIndex));

                        // Récupérez l'index de Column placeDisponible dans l'instruction de requête SQL.
                        int TablePlaceDisponibleIndex = reader.GetOrdinal("placeDisponible");// 2
                        long TablePlaceDisponible = Convert.ToInt64(reader.GetValue(TablePlaceDisponibleIndex));

                        Table table = new Table();
                        table.Id = (int)Convert.ToInt64(TableId);
                        table.PlaceDisponible = (int)Convert.ToInt64(TablePlaceDisponible); ;
                        table.PlaceTotal = (int)Convert.ToInt64(TablePlaceTotal); ;

                        AddTable(table);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Table Id: " + TableId);
                        Console.WriteLine("Table PlaceDisponible: " + table.PlaceDisponible);
                        Console.WriteLine("Table PlaceTotal:" + table.PlaceTotal);

                    }
                }
            }

        }

        public void Add(Table table)
        {
            try
            {
                connection.Open();

                string sql = "Insert into Table (placeDisponible, placeTotal) "
                         + " values (@placeDisponible, @placeTotal) ";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Créez un objet Parameter.
                SqlParameter placeDisponibleParam = new SqlParameter("@placeDisponible", SqlDbType.Int);
                placeDisponibleParam.Value = table.PlaceDisponible;
                cmd.Parameters.Add(placeDisponibleParam);
                // Créez un objet Parameter.
                SqlParameter placeTotaleParam = new SqlParameter("@placeTotal", SqlDbType.Int);
                placeTotaleParam.Value = table.PlaceTotal;
                cmd.Parameters.Add(placeTotaleParam);

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    AddTable(table);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Closez la connexion.
                connection.Close();
                // Éliminez l'objet, libérant les ressources.
                connection.Dispose();
            }
        }

        public void Update(Table table)
        {
            try
            {
                connection.Open();

                string sql = "Update Table set placeDisponible=@placeDisponible, placeTotal=@placeTotal where id = @id";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Ajoutez et définissez de la valeur pour le paramètre.
                cmd.Parameters.Add("@placeDisponible", SqlDbType.Int).Value = table.PlaceDisponible;
                cmd.Parameters.Add("@placeTotal", SqlDbType.Int).Value = table.PlaceTotal;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = table.Id;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    UpdateTable(table);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Closez la connexion.
                connection.Close();
                // Éliminez l'objet, libérant les ressources.
                connection.Dispose();
            }
        }

        public void Delete(Table table)
        {
            try
            {
                connection.Open();

                string sql = "Delete from Table where id = @id ";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = table.Id;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    DeleteTable(table);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Closez la connexion.
                connection.Close();
                // Éliminez l'objet, libérant les ressources.
                connection.Dispose();
            }
        }

    }
}
