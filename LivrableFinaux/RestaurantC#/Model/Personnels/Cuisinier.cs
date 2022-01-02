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
    class Cuisinier : Personne
    {
        [NotMapped]
        public static int numero = 0;

        public Cuisinier() : base()
        {
            Nom = NameGeneration.GenerateWord();
            Prenom = "Cuis" + numero;
            numero++;
        }
        public void CookMeal(List<Commande> commandes)
        {
            if (commandes.Count <= 0)
            {
                Console.WriteLine("\nCuisinier : " + Nom + " " + Prenom + " en attente de commandes à cuisiner\n");
            } else
            {
                foreach (Commande commande in commandes)
                {
                    TimerEvent timer = new TimerEvent("Commande du client " + commande.Client.Nom + " " + commande.Client.Prenom + " est en pleine réalisation par le chef " + Nom + " " + Prenom + ".\n");

                    List<IngredientUtilise> ingredientUtilises = new List<IngredientUtilise>();
                    List<UstensilUtilise> ustensilUtilises = new List<UstensilUtilise>();

                    Recette recette = new Recette();

                    int preparationMeal = 0;
                    foreach (Recipe recipe in commande.Recipes)
                    {
                        ingredientUtilises.AddRange(recipe.IngredientUtilise);
                        ustensilUtilises.AddRange(recipe.UstensilUtilise);
                        preparationMeal += recipe.CookingTime;
                        recette.Nom += recipe.Name + " ";
                        recette.Consumption_time += recipe.CookingTime;
                        recette.Prix += recipe.Prix;
                    }
                    recette.Ready = true;

                    CommisCuisinier commisCuisinier =  new CommisCuisinier();
                    commisCuisinier.MakeReadIngredient(ingredientUtilises);

                    int passTime = timer.GetCompteur();

                    while (timer.GetCompteur() < preparationMeal - passTime)
                    {}

                    if (timer.GetCompteur() >= preparationMeal)
                    {
                        timer.Stop();
                    }

                    ProvideMeal(commisCuisinier, commande.Client, recette, commande.Table, ustensilUtilises);
                }
            }
        }
        
        public void ProvideMeal(CommisCuisinier commis,Client client, Recette recette, Table table, List<UstensilUtilise> ustensilUtilises)
        {
            commis.ProvideMeal(client, recette, table, ustensilUtilises);
        }
    }
}
