using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Cuisine
{
    [Table("Ingredient")]
    class Ingredient
    {
        public Ingredient()
        {
            Id = 0;
            Quantite = 0;
            Nom = "";
            Categorie = CategorieIngredient.None;
        }

        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(Order = 1)]
        [StringLength(25)]
        public string Nom { get; set; }

        [Column(Order = 2)]
        public int Quantite { get; set; }

        [Required]
        [Column(Order = 3)]
        [StringLength(50)]
        private CategorieIngredient Categorie { get; set; }

        public Ingredient(string name, int nbr, CategorieIngredient type)
        {
            Nom = name;
            Quantite = nbr;
            Categorie = type;
        }
    }
}
