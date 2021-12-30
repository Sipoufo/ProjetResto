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
    using ProjectResto.Models.Bdd;
    using ProjectResto.Controllers.Restaurant;
    using ProjectResto.Controllers.Personnels;
    class CommisCuisinier : Personne
    {
        [NotMapped]
        public static int numero = 0;

        public CommisCuisinier() : base()
        {
            Nom = NameGeneration.GenerateWord();
            Prenom = "ComCuis" + numero;
            numero++;
        }

        public void MakeReadIngredient(List<IngredientUtilise> ingredients)
        {
            Console.WriteLine("\nCommis Cuisinier -> " + Nom + " " + Prenom + " Appretes les ingredients qui sont : " +
                "");
            foreach(IngredientUtilise ingredient in ingredients)
            {
                Console.WriteLine("Ingredient: " + ingredient.Ingredient.Nom);
            }
            Console.WriteLine("\n");

        }

        public void ProvideMeal(Client client, Recette recette, Table table, List<UstensilUtilise> ustensilUtilises)
        {
            Serveur serveur = new Serveur();
            serveur.Serve(client, recette);
            serveur.ClearTable(table, ustensilUtilises);
        }
    }
}
