using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Cuisine
{
    [Table("UstensilUtilise")]
    class UstensilUtilise
    {
        public UstensilUtilise()
        {
            IdUstensil = 0;
            IdRecipe = 0;
            QuantiteUtilise = 0;
            Ustensil = new Ustensil();
            Recipe = new Recipe();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUstensil { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRecipe { get; set; }

        [Column(Order = 2)]
        public int QuantiteUtilise { get; set; }

        public Ustensil Ustensil { get; set; }

        public Recipe Recipe { get; set; }
    }
}
