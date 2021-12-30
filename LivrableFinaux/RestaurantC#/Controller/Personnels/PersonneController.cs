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

namespace ProjectResto.Controllers.Personnels
{
    using ProjectResto.Models.Personnels;
    using ProjectResto.Models.BDD;
    class PersonneController
    {
        public static List<Personne> personnes;
        public SqlConnection connection;
        private String _table_name;

        public String GetTableName() { 
            return this._table_name; 
        }
  
        public void SetTableName(String table) { 
            this._table_name = table; 
        }

        public PersonneController()
        {
            personnes = new List<Personne>();
            connection = DBUtils.GetDBConnection();
        }
        public PersonneController(String table_name)
        {
            personnes = new List<Personne>();
            connection = DBUtils.GetDBConnection();
            this._table_name = table_name;
        }

        public void CreateTable()

        {
            try
            {
                connection.Open();

                Personne personne = new Personne();
                String sql = personne.GetScript(this._table_name);

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

        public void AddPersonne(Personne Personne)
        {
            personnes.Add(Personne);
        }

        public void DeletePersonne(Personne Personne)
        {
            personnes.Remove(Personne);
        }

        public void UpdatePersonne(Personne Personne)
        {
            personnes.Remove(Personne);
            personnes.Add(Personne);
        }


        public void All()
        {
            try
            {
                connection.Open();

                QueryPersonne(connection);
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

        private void QueryPersonne(SqlConnection conn)
        {
            string sql = "Select id, nom, prenom from " + this._table_name;

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
                        //int PersonneIdIndex = reader.GetOrdinal("id"); // 0
                        long PersonneId = Convert.ToInt64(reader.GetValue(0));

                        // Récupérez l'index de Column nom dans l'instruction de requête SQL.
                        int PersonneNomIndex = reader.GetOrdinal("nom");// 2
                        string PersonneNom = reader.GetString(PersonneNomIndex);

                        // Récupérez l'index de Column prenom dans l'instruction de requête SQL.
                        int PersonnePrenomIndex = reader.GetOrdinal("prenom");// 2
                        string PersonnePrenom = reader.GetString(PersonnePrenomIndex);

                        // L'index de colonne Mng_Id trong dans l'instruction de requête SQL.
                        /*
                            int mngIdIndex = reader.GetOrdinal("Mng_Id");

                            long? mngId = null;


                            if (!reader.IsDBNull(mngIdIndex))
                            {
                                mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                            }
                        */

                        Personne Personne = new Personne();
                        Personne.Nom = PersonneNom;
                        Personne.Id = (int) PersonneId;
                        Personne.Prenom = PersonnePrenom;

                        AddPersonne(Personne);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Personne Id: " + PersonneId);
                        Console.WriteLine("Personne Nom: " + PersonneNom);
                        Console.WriteLine("Personne Prenom:" + PersonnePrenom);

                    }
                }
            }

        }

        public void Add(Personne Personne)
        {
            try
            {
                connection.Open();

                string sql = "Insert into " + this._table_name + " (nom, prenom) "
                         + " values (@nom, @prenom) ";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Créez un objet Parameter.
                SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar);
                nomParam.Value = Personne.Nom;
                cmd.Parameters.Add(nomParam);

                // Ajoutez le paramètre @Prenom (Écrire plus court).
                SqlParameter prenomParam = cmd.Parameters.Add("@prenom", SqlDbType.VarChar);
                prenomParam.Value = Personne.Prenom;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    AddPersonne(Personne);
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

        public void Update(Personne Personne)
        {
            try
            {
                connection.Open();

                string sql = "Update " + this._table_name + " set nom = @nom, prenom = @prenom where id = @id";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Ajoutez et définissez de la valeur pour le paramètre.
                cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = Personne.Nom;
                cmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = Personne.Prenom;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = Personne.Id;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    UpdatePersonne(Personne);
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

        public void Delete(Personne Personne)
        {
            try
            {
                connection.Open();

                string sql = "Delete from " + this._table_name + " where id = @id ";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = Personne.Id;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    DeletePersonne(Personne);
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
