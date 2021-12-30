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
    class ClientController
    {
        public static List<Client> clients;
        private readonly SqlConnection connection;

        public ClientController()
        {
            clients = new List<Client>();
            connection = DBUtils.GetDBConnection();
        }

        public int NumberOfClientWhoAreServe()
        {
            int number = 0;
            foreach (Client client in clients.ToArray()){
                if (client.Serve)
                {
                    number++;
                }
            }

            return number;
        }

        public int NumberOfClientWhoAreReserve()
        {
            int number = 0;
            foreach (Client client in clients.ToArray()){
                if (client.Reserve)
                {
                    number++;
                }
            }

            return number;
        }

        public int NumberOfClientWhoAreFinish()
        {
            int number = 0;
            foreach (Client client in clients.ToArray()){
                if (client.FinishEat)
                {
                    number++;
                }
            }

            return number;
        }

        public int NumberOfClientWhoAreInstall()
        {
            int number = 0;
            foreach (Client client in clients.ToArray()){
                if (client.Install)
                {
                    number++;
                }
            }

            return number;
        }
        
        public static List<Client> ClientWhoAreServing()
        {
            List<Client> c = new List<Client>();
            foreach (Client client in clients.ToArray()){
                if (client.Serve)
                {
                    c.Add(client);
                }
            }

            return c;
        }

        public List<Client> ClientWhoAreReserving()
        {
            List<Client> c = new List<Client>();
            foreach (Client client in clients.ToArray())
            {
                if (client.Reserve)
                {
                    c.Add(client);
                }
            }

            return c;
        }

        public List<Client> ClientWhoAreFinishing()
        {
            List<Client> c = new List<Client>();
            foreach (Client client in clients.ToArray())
            {
                if (client.FinishEat)
                {
                    c.Add(client);
                }
            }

            return c;
        }

        public List<Client> ClientWhoAreInstalling()
        {
            List<Client> c = new List<Client>();
            foreach (Client client in clients.ToArray())
            {
                if (client.Install)
                {
                    c.Add(client);
                }
            }

            return c;
        }

        // Communication avec un bd
        public void CreateTable()

        {
            try
            {
                connection.Open();

                Client client = new Client();

                StringBuilder script = new StringBuilder();
                script.AppendLine("serve Varchar (50) NOT NULL ,");
                script.AppendLine("reserve Varchar (50) NOT NULL ,");
                script.AppendLine("install Varchar (50) NOT NULL ,");
                script.AppendLine("finishEat Varchar (50) NOT NULL ,");

                String sql = client.GetScript("Client", script.ToString());

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

        public void AddClient(Client client)
        {
            clients.Add(client);
        }

        public void DeleteClient(Client client)
        {
            clients.Remove(client);
        }

        public void UpdateClient(Client client)
        {
            clients.Remove(client);
            clients.Add(client);
        }

        public void All()
        {
            try
            {
                connection.Open();

                QueryClient(connection);
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

        private void QueryClient(SqlConnection conn)
        {
            string sql = "Select id, nom, prenom, reserve, install, serve, finishEat from Client";

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
                        int clientIdIndex = reader.GetOrdinal("id"); // 0
                        long clientId = Convert.ToInt64(reader.GetValue(0));

                        // Récupérez l'index de Column nom dans l'instruction de requête SQL.
                        int clientNomIndex = reader.GetOrdinal("nom");// 2
                        string clientNom = reader.GetString(clientNomIndex);

                        // Récupérez l'index de Column prenom dans l'instruction de requête SQL.
                        int clientPrenomIndex = reader.GetOrdinal("prenom");// 2
                        string clientPrenom = reader.GetString(clientPrenomIndex);

                        // Récupérez l'index de Column reserve dans l'instruction de requête SQL.
                        int clientReserveIndex = reader.GetOrdinal("reserve");// 2
                        string clientReserve = reader.GetString(clientReserveIndex);

                        // Récupérez l'index de Column install dans l'instruction de requête SQL.
                        int clientInstallIndex = reader.GetOrdinal("install");// 2
                        string clientInstall = reader.GetString(clientInstallIndex);
                        
                        // Récupérez l'index de Column serve dans l'instruction de requête SQL.
                        int clientServeIndex = reader.GetOrdinal("serve");// 2
                        string clientServe = reader.GetString(clientServeIndex);

                        // Récupérez l'index de Column finishEat dans l'instruction de requête SQL.
                        int clientFinishEatIndex = reader.GetOrdinal("serve");// 2
                        string clientFinishEat = reader.GetString(clientFinishEatIndex);

                        // L'index de colonne Mng_Id trong dans l'instruction de requête SQL.
                        /*
                            int mngIdIndex = reader.GetOrdinal("Mng_Id");

                            long? mngId = null;


                            if (!reader.IsDBNull(mngIdIndex))
                            {
                                mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                            }
                        */

                        Client client = new Client();
                        client.Nom = clientNom;
                        client.Id = (int)Convert.ToInt64(clientId);
                        client.Prenom = clientPrenom;
                        client.Reserve = bool.Parse(clientReserve);
                        client.Install = bool.Parse(clientInstall);
                        client.Serve = bool.Parse(clientServe);
                        client.FinishEat = Convert.ToBoolean(clientFinishEat);

                        AddClient(client);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("Client Id: " + clientId);
                        Console.WriteLine("Client Nom: " + clientNom);
                        Console.WriteLine("Client Prenom:" + clientPrenom);
                        Console.WriteLine("Client Reserve:" + clientReserve);
                        Console.WriteLine("Client Install:" + clientInstall);
                        Console.WriteLine("Client Serve:" + clientServe);
                        Console.WriteLine("Client FinishEat:" + clientFinishEat);

                    }
                }
            }

        }

        public void Add(Client client)
        {
            try
            {
                connection.Open();

                string sql = "Insert into Client (nom, prenom, reserve, install, serve, finishEat) "
                         + " values (@nom, @prenom, @reserve, @install, @serve, @finishEat) ";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Créez un objet Parameter.
                SqlParameter nomParam = new SqlParameter("@nom", SqlDbType.VarChar);
                nomParam.Value = client.Nom;
                cmd.Parameters.Add(nomParam);

                // Ajoutez le paramètre @Prenom (Écrire plus court).
                SqlParameter prenomParam = cmd.Parameters.Add("@prenom", SqlDbType.VarChar);
                prenomParam.Value = client.Prenom;
                
                // Ajoutez le paramètre @Reserve (Écrire plus court).
                SqlParameter ReserveParam = cmd.Parameters.Add("@reserve", SqlDbType.VarChar);
                ReserveParam.Value = client.Reserve + ""; 
                                
                // Ajoutez le paramètre @Install (Écrire plus court).
                SqlParameter InstallParam = cmd.Parameters.Add("@install", SqlDbType.VarChar);
                InstallParam.Value = client.Install + ""; 
                
                // Ajoutez le paramètre @Serve (Écrire plus court).
                SqlParameter ServeParam = cmd.Parameters.Add("@serve", SqlDbType.VarChar);
                ServeParam.Value = client.Serve + "";

                // Ajoutez le paramètre @FinishEat (Écrire plus court).
                SqlParameter FinishEatParam = cmd.Parameters.Add("@finishEat", SqlDbType.VarChar);
                FinishEatParam.Value = client.FinishEat + "";

                // Ajoutez le paramètre @finishEat (Écrire plus court).
                //cmd.Parameters.Add("@finishEat", SqlDbType.VarChar).Value = client.FinishEat + ""; ;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    AddClient(client);
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

        public void Update(Client client)
        {
            try
            {
                connection.Open();

                string sql = "Update Client set nom = @nom, prenom = @prenom, " +
                "reserve = @reserve, install = @install , serve = @serve" +
                " finishEat = @finishEat where id = @id";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                // Ajoutez et définissez de la valeur pour le paramètre.
                cmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = client.Nom;
                cmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = client.Prenom;
                cmd.Parameters.Add("@reserve", SqlDbType.VarChar).Value = client.Reserve + "";
                cmd.Parameters.Add("@Install", SqlDbType.VarChar).Value = client.Install + "";
                cmd.Parameters.Add("@serve", SqlDbType.VarChar).Value = client.Serve + "";
                cmd.Parameters.Add("@finishEat", SqlDbType.VarChar).Value = client.FinishEat + "";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = client.Id;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    UpdateClient(client);
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

        public void Delete(Client client)
        {
            try
            {
                connection.Open();

                string sql = "Delete from Client where id = @id ";

                // Créez un objet Command à partir de l'objet Connection.
                SqlCommand cmd = connection.CreateCommand();

                // Set Command Text
                cmd.CommandText = sql;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = client.Id;

                // Exécutez Command (Pour supprimer (delete), insérer (insert), mettre à jour (update)).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);

                if (rowCount > 0)
                {
                    DeleteClient(client);
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
