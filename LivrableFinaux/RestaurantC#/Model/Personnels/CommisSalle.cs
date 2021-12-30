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
    class CommisSalle : Personne
    {
        [NotMapped]
        public static int numero = 0;

        public CommisSalle() : base()
        {
            Nom = NameGeneration.GenerateWord();
            Prenom = "ComSalle" + numero;
            numero++;
        }
        public void SetUpTable(Table table)
        {

            if (table.PlaceDisponible > 0)
            {
                Console.WriteLine("\nLa Table " + table.Id + " à été dréssé par " +
                    Nom + " " + Prenom + "(CommisSalle)");
                table.PlaceDisponible--;
                Console.WriteLine("\nUne place à été libéré sur la table" +
                    table.Id + "\n");
            }
        }
    }
}
