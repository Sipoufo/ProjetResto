using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectResto.Models.Cuisine
{
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.Cuisine;
    using ProjectResto.Models.Personnels;
    using ProjectResto.Controllers.Restaurant;
    using ProjectResto.Controllers.Personnels;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Commande")]
    class Commande
    {
        public Commande()
        {
            Id = 0;
            IdClient = 0;
            IdTable = 0;
            Client = new Client();
            Table = new Table();
        }

        [Key]
        public int Id { get; set; }

        public int IdClient { get; set; }
        public int IdTable { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public Client Client { get; set; }
        public Table Table { get; set; }

        public Commande(int idClient)
        {
            IdClient = idClient;
        }
        
        public Commande(int idClient, List<Recipe> plats)
        {
            IdClient = idClient;
            Recipes = plats;
        }        

        public Commande(int idClient, List<Recipe> plats, Client client)
        {
            IdClient = idClient;
            Recipes = plats;
            Client = client;
        }

    }
}
