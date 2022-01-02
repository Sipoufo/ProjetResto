using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Personnels
{
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.Bdd;
    using ProjectResto.Models.BDD;
    using ProjectResto.Controllers.Restaurant;
    using ProjectResto.Controllers.Personnels;
    class MaitreHotel : Personne
    {
        [NotMapped]
        public static int numero = 0;

        public MaitreHotel():base()
        {
            Id = 0;
            Nom = "Kepya";
            Prenom = "Christian";
            numero++;
        }
        public void ReceiveClient()
        {

            List<Client> clients = ClientController.clients;
            List<Table> tables = TableController.tables;
            ClientController clientController = new ClientController();

            foreach (Client client in clients)
            {
                Console.WriteLine("\nMaitre Hotel -> Bienvenue au client " + client.Nom + "" + client.Prenom);
                Console.WriteLine("Client" + client.Nom + "" + client.Prenom + " à été récus par le maitre d'hotel\n");
                if (AssignTable(client, 0, tables))
                {
                    client.Install = true;
                    clientController.Update(client);
                }
                else
                {
                    Console.WriteLine("\nClient : " + client.Nom + " " + client.Prenom + " est en attente\n");
                    tables = TableController.tables;
                }
            }
        }
        public bool AssignTable(Client client, int index, List<Table> tables)
        {
            Table table = new Table();
            ChefRang chefRang = new ChefRang();
            int length = tables.ToArray().Length;
            do
            {
                table = tables.ToArray()[index];
                index++;
            }
            while ((table.PlaceDisponible == 0) && index < length);

            if (table.PlaceDisponible > 0)
            {
                table.AddClient(client);
                table.PlaceDisponible--;
                chefRang.InstallClient(client, table);
                return true;
            } else
            {
                return false;
            }

        }

    }
}
