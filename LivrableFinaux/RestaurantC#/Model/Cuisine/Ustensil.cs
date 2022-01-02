using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Cuisine
{
    [Table("Ustensil")]
    class Ustensil
    {

        public Ustensil()
        {
            Id = 0;
            Nom = "";
            Quantite = 0;
            Type = TypeUstensil.Cuisine;
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
        [StringLength(50)]
        [Column(Order = 3)]
        public TypeUstensil Type { get; set; }

        public Ustensil(string name, int nbr)
        {
            Nom = name;
            Quantite = nbr;
        }

        public Ustensil(string name, int nbr, TypeUstensil type)
        {
            Nom = name;
            Quantite = nbr;
            Type = type;
        }
    }
}
