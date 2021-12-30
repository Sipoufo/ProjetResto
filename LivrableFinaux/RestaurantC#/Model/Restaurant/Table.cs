using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Restaurant
{
    using ProjectResto.Models.Personnels;
    using ProjectResto.Models.Cuisine;
    class Table
    {
        [Key]
        public int Id { get; set; }
        public int PlaceTotal { get; set; } = 4;
        public int PlaceDisponible { get; set; } = 4;

        [NotMapped]
        public List<Client> Clients { get; set; }
        public List<Commande> Commandes { get; set; }

        public void AddClient(Client client)
        {
            Console.WriteLine("\nClient : " + client.Nom + " " + client.Prenom + " à eté assigné à la table : " + Id);
            Console.WriteLine("Maitre Hotel -> Client : " + client.Nom + " " + client.Prenom + " à eté assigné à la table : " + Id + "\n");
            Clients.Add(client);
        }

        public void RemoveClient(Client client)
        {
            Console.WriteLine("\nClient : " + client.Nom + " " + client.Prenom + " à liberer la table : " + Id + ". Il a finit de manger\n");
            Clients.Remove(client);
        }
    }
}
