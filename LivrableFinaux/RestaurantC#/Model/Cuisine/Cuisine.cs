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
    class Cuisine
    {
        public Cuisine()
        {
            ChefCuisinier = new ChefCuisinier();
            IdChefCuisinier = 0;
            NombrePlongeur = 0;
            NombreCuisiner = 0;
            NombreCommisCuisinier = 0;
        }
        public ChefCuisinier ChefCuisinier { get; set; }

        public int IdChefCuisinier { get; set; }
        public int NombrePlongeur { get; set; } = 4;
        public int NombreCuisiner { get; set; } = 6;
        public int NombreCommisCuisinier { get; set; } = 6;
    }
}
