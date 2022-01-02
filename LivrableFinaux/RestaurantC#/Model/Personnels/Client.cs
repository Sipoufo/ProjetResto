using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProjectResto.Models.Personnels
{
    using ProjectResto.Models.Restaurant;
    using ProjectResto.Models.Cuisine;
    using ProjectResto.Models.Bdd;
    using ProjectResto.Controllers.Restaurant;
    using ProjectResto.Controllers.Personnels;

    [Table("Client")]
    class Client : Personne
    {
        [NotMapped]
        public static int numero = 0;

        [Column(Order = 4)]
        private bool reserve = false;

        [Column(Order = 5)]
        private bool install = false;

        [Column(Order = 6)]
        private bool serve = false;

        [Column(Order = 7)]
        private bool finishEat = false;

        public List<Commande> Commande { get; set; }

        public bool Reserve
        {
            get { return this.reserve; }
            set { this.reserve = value; }
        }
        
        public bool Install
        {
            get { return this.install; }
            set { this.install = value; }
        } 
        
        public bool Serve
        {
            get { return this.serve; }
            set { this.serve = value; }
        }

        public bool FinishEat
        {
            get { return this.finishEat; }
            set { this.finishEat = value; }
        }

        public Client() : base()
        {
            Id = 0;
            Nom = NameGeneration.GenerateWord();
            Prenom = "Cli" + numero;
            numero++;
        }
        public void PassCommand(ChefRang chefRang)
        {
            int length = Commande.ToArray().Length;
            Commande commande = Commande.ToArray()[length - 1];
            Console.WriteLine("\nMr : " + Nom + " " + Prenom + " vos choix sont entre autres : ");
            int i = 1;
            foreach (Recipe plat in commande.Recipes)
            {
                Console.WriteLine("Choix:\n" + i + "- " + plat.Prix + " -> " + plat.Prix + " Fcfa. (" + plat.Description + ")");
                i++;
            }

            chefRang.TakeCommand(commande);
        }

        public void DoReservation()
        {
            Reserve = true;
        }

        public void PaidInvoice()
        {

        }

    }
}
