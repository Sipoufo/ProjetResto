using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectResto.Models.Cuisine
{
    [Table("STOCK")]
    class Stock
    {
        public Stock()
        {
            Id = 0;
            Date = new DateTime();
            Quantite = 0;
            Prix = 0;
            IdIingredient = 0;
            Ingredient = new Ingredient();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Quantite { get; set; }

        public double Prix { get; set; }

        public int IdIingredient { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
