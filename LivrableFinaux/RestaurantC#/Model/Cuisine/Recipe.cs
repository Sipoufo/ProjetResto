using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Cuisine
{
    [Table("Recipe")]
    class Recipe
    {
        public Recipe()
        {
            IngredientUtilise = new HashSet<IngredientUtilise>();
            UstensilUtilise = new HashSet<UstensilUtilise>();
            Id = 0;
            Name = "";
            Description = "";
            CookingTime = 0;
            Prix = 0;
            Categorie = TypePlat.None;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public int CookingTime { get; set; }
        public int Prix { get; set; }

        [Required]
        [StringLength(126)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public TypePlat Categorie { get; set; }

        public ICollection<IngredientUtilise> IngredientUtilise { get; set; }

        public ICollection<UstensilUtilise> UstensilUtilise { get; set; }
    }
}
