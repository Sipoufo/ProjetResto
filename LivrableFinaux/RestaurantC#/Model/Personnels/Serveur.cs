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
    [Table("Serveur")]
    class Serveur : Personne
    {
        [NotMapped]
        public static int numero = 0;

        public Serveur() : base()
        {
            Id = 0;
            Nom = NameGeneration.GenerateWord();
            Prenom = "Serv" + numero;
            numero++;
        }

        public void Serve(Client client, Recette recette)
        {
            ClientController clientController = new ClientController();
            Console.WriteLine("Serveur " + Nom + " " + Prenom + " -> Mr " + client.Nom + " " + client.Prenom + " Votre repas est servi.\nRepas: " + recette.Nom);
            TimerEvent timer = new TimerEvent(recette.Consumption_time, client.Nom + " " + client.Prenom + " est entrain de manger " + recette.Nom);

            while(timer.GetCompteur() < recette.Consumption_time)
            {}

            if (timer.GetCompteur() >= recette.Consumption_time)
            {
                client.Serve = true;
                client.FinishEat = true;
                client.Install = true;
                clientController.Update(client);
                clientController.DeleteClient(client);
                timer.Stop();
            }

        }

        public void ClearTable(Table table, List<UstensilUtilise> ustensilUtilises)
        {
            Console.WriteLine("Serveur " + Nom + " " + Prenom + " débarrasse la table " + table.Id);
            new Plongeur().WhashUstensil(ustensilUtilises);
            new CommisSalle().SetUpTable(table);
        }
    }
}
