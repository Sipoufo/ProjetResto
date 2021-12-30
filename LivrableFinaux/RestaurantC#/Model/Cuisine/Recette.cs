using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectResto.Models
{
    using ProjectResto.Models.Cuisine;
    class Recette
    {
        public String Nom { set; get; }
        public double Prix { set; get; }
        public int Consumption_time { set; get; }
        public bool Ready { set; get; }

        public Recette(string name, int time, int price)
        {
            Nom = name;
            Consumption_time = time;
            Prix = price;
            Ready = false;
        }

        public Recette()
        {
            Nom = "";
            Consumption_time = 0;
            Prix = 0;
            Ready = false;
        }
    }
}
