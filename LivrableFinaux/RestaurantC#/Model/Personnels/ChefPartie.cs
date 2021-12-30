using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Personnels
{
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.Cuisine;
    using ProjectResto.Models.Personnels;
    using ProjectResto.Controllers.Restaurant;
    using ProjectResto.Controllers.Personnels;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    class ChefPartie : Personne
    {
        public List<Commande> Commandes { get; set; } = new List<Commande>();

        public ChefPartie(Commande commande)
        {
            Commandes.Add(commande);
            OrganizedChicken();
        }

        public void OrganizedChicken()
        {
            // Take All Cuisine
            Cuisine cuisine = new Cuisine();
            cuisine.ChefCuisinier = new ChefCuisinier();
            ChefCuisinier.Commandes.AddRange(Commandes);
            cuisine.ChefCuisinier.OrganizedCommand(cuisine);
        }

    }
}
