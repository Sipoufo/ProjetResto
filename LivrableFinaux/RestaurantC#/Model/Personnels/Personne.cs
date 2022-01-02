using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models.Personnels
{
    class Personne
    {
        [Key]
        [Column(Order = 0)]
        private int id;

        [Required]
        [StringLength(25)]
        [Column(Order = 1)]
        private string nom;

        [Required]
        [StringLength(25)]
        [Column(Order = 3)]
        private string prenom;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public Personne()
        {
            Id = 0;
            Nom = "";
            Prenom = "";
        }

        public String GetScript(String table, String field="empty")
        {
            StringBuilder script = new StringBuilder();

            script.AppendLine("CREATE TABLE " + table);
            script.AppendLine("(");
            script.AppendLine("\t id Int Auto_increment  NOT NULL ,");
            script.AppendLine("nom  Varchar (50) NOT NULL ,");
            script.AppendLine("prenom  Varchar (50) NOT NULL ,");
            if (field != "empty")
            {
                script.AppendLine(field);

            }
            script.AppendLine(",CONSTRAINT " + table + "_PK PRIMARY KEY (id)");
            script.AppendLine(")ENGINE=InnoDB;");

            return script.ToString();
        }

    }
}
