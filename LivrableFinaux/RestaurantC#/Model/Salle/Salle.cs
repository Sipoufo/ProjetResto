using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Salle
{
    [NotMapped]
    class Salle
    {
        public int NombreRangeParSecteur
        {
            get; set;
        }

        //Le nombre de carrés dans la salle
        public int NombreSecteur{ get; set; }

        //Le nombre de tables par rang
        public int NombreTableParRang { get; set; }
    }
}
