using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Personnels
{
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.Cuisine;
    using ProjectResto.Models.Bdd;
    using ProjectResto.Controllers.Personnels;
    class ChefRang : Personne
    {
        [NotMapped]
        public static int numero = 0;
        public ChefRang() : base()
        {
            Id = 0;
            Nom = NameGeneration.GenerateWord();
            Prenom = "Cli" + numero;
            numero++;
        }
        public void PresentMap(Client client)
        {
            List<Recipe> plats = ChefRangController.plats;
            Console.WriteLine("\nConcernant nos plats Mr : " + client.Nom + " " + client.Prenom + " nous avons : ");
            int i = 1;
            foreach (Recipe plat in plats)
            {
                Console.WriteLine("Menus:\n" + i + "- " + plat.Prix + " -> " + plat.Prix + " Fcfa. (" + plat.Description + ")");
                i++;
            }

            Random rd = new Random();
            int rand_num0fPlat = rd.Next(1, plats.Count);

            List<Recipe> platSelectiones = new List<Recipe>();

            while (rand_num0fPlat > 0)
            {
                int rand_pos0fPlat = rd.Next(1, plats.Count);
                platSelectiones.Add(plats.ToArray()[rand_num0fPlat - 1]);

                rand_num0fPlat--;
            }

            client.Commande.Add(new Commande(client.Id, platSelectiones));
            client.PassCommand(this);
        }

        public void TakeCommand(Commande commande)
        {
            new ChefPartie(commande);
        }

        public void InstallClients(List<Client> clients, Table table)
        {
            foreach (Client client in clients)
            {
                Console.WriteLine("\nBienvenue Mr : " + client.Nom + " " + client.Prenom + " à la table : " + table.Id + ".Veuillez vous assoir s'il vous plait\n");
                Console.WriteLine("Chef Rang -> Bienvenue Mr : " + client.Nom + " " + client.Prenom + " à la table : " + table.Id + ".Veuillez vous assoir s'il vous plait\n");
                PresentMap(client);
            }
        }
        public void InstallClient(Client client, Table table)
        {
            Console.WriteLine("\nBienvenue Mr : " + client.Nom + " " + client.Prenom + " à la table : " + table.Id + ".Veuillez vous assoir s'il vous plait\n");
            Console.WriteLine("Chef Rang -> Bienvenue Mr : " + client.Nom + " " + client.Prenom + " à la table : " + table.Id + ".Veuillez vous assoir s'il vous plait\n");

            PresentMap(client);
        }
    }
}
