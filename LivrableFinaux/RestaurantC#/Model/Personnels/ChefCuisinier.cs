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
    class ChefCuisinier : Personne
    {
        [NotMapped]
        static int numero = 0;
        public static List<Commande> Commandes { get; set; } = new List<Commande>();

        public ChefCuisinier()
        {
            Nom = "Bouanga";
            Prenom = "Mirlaine";
            numero++;
        }

        public void OrganizedCommand(Cuisine cuisine)
        {
            int length = Commandes.ToArray().Length;
            if (length % cuisine.NombreCuisiner == 0)
            {
                int index = 0;
                for(int i = 0; i < cuisine.NombreCuisiner; i++)
                {
                    //Starthread
                    Cuisinier cuisinier = new Cuisinier();
                    cuisinier.CookMeal(Commandes.GetRange(index, length / cuisine.NombreCuisiner));
                    Commandes.RemoveRange(index, length / cuisine.NombreCuisiner);
                    index += length / cuisine.NombreCuisiner;
                }
            } else
            {
                int index = 0;
                int reste = 0;
                int j = 1;
                for (int i = 0; i < cuisine.NombreCuisiner; i++)
                {
                    Cuisinier cuisinier = new Cuisinier();
                    cuisinier.CookMeal(Commandes.GetRange(index, length / cuisine.NombreCuisiner + j));
                    Commandes.RemoveRange(index, length / cuisine.NombreCuisiner + j);

                    if (reste <= 0)
                    {
                        j = 0;
                    } else
                    {
                        reste--;
                    }

                    index += length / cuisine.NombreCuisiner;
                }
            }
        }
    }
}
