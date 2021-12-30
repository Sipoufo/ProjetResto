using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Personnels
{
    using ProjectResto.Models.Cuisine;
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.Personnels;
    using ProjectResto.Models.Bdd;
    using ProjectResto.Controllers.Restaurant;
    using ProjectResto.Controllers.Personnels;
    class Plongeur : Personne
    {
        [NotMapped]
        public static int numero = 0;
        
        [NotMapped]
        public int NombreAsietteNonLave { set; get; }  
        
        [NotMapped]
        public int NombreAsiette { set; get; }

        public Plongeur() : base()
        {
            Id = 0;
            Nom = NameGeneration.GenerateWord();
            Prenom = "Plong" + numero;
            NombreAsiette = 0;
            NombreAsietteNonLave = 0;
            numero++;
        }
        public void WhashUstensil(List<UstensilUtilise> ustensilUtilises)
        {
            foreach (UstensilUtilise ustensil in ustensilUtilises)
            {
                Console.WriteLine("Plongeur: " + Nom + " " + Prenom + " -> lave l'ustensile " + ustensil.Ustensil.Nom);
            }
        }
    }
}
