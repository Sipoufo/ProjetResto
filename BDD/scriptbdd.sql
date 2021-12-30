#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: Recette
#------------------------------------------------------------

CREATE TABLE Recette(
        id_rtte    Int  Auto_increment  NOT NULL ,
        Nom_rtte   Varchar (50) NOT NULL ,
        Gategories Varchar (50) NOT NULL
	,CONSTRAINT Recette_PK PRIMARY KEY (id_rtte)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Ingredients
#------------------------------------------------------------

CREATE TABLE Ingredients(
        id_its  Int  Auto_increment  NOT NULL ,
        Nom_its Varchar (50) NOT NULL
	,CONSTRAINT Ingredients_PK PRIMARY KEY (id_its)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Serveurs
#------------------------------------------------------------

CREATE TABLE Serveurs(
        id_svrs    Int  Auto_increment  NOT NULL ,
        Nom_svr    Char (50) NOT NULL ,
        Premon_svr Char (50) NOT NULL
	,CONSTRAINT Serveurs_PK PRIMARY KEY (id_svrs)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Chef_partie
#------------------------------------------------------------

CREATE TABLE Chef_partie(
        id_cp       Int  Auto_increment  NOT NULL ,
        Nom_cp      Varchar (50) NOT NULL ,
        Prenom_cp   Varchar (50) NOT NULL ,
        Type_partie Varchar (50) NOT NULL
	,CONSTRAINT Chef_partie_PK PRIMARY KEY (id_cp)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Commis
#------------------------------------------------------------

CREATE TABLE Commis(
        id_commis  Int  Auto_increment  NOT NULL ,
        Nom_cms    Varchar (50) NOT NULL ,
        Prenom_cms Varchar (50) NOT NULL ,
        Type_cms   Varchar (50) NOT NULL ,
        id_cp      Int NOT NULL
	,CONSTRAINT Commis_PK PRIMARY KEY (id_commis)

	,CONSTRAINT Commis_Chef_partie_FK FOREIGN KEY (id_cp) REFERENCES Chef_partie(id_cp)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table Maitre_d_hotel
#------------------------------------------------------------

CREATE TABLE Maitre_d_hotel(
        id_MH  Int  Auto_increment  NOT NULL ,
        Nom_MH Varchar (50) NOT NULL
	,CONSTRAINT Maitre_d_hotel_PK PRIMARY KEY (id_MH)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Clients
#------------------------------------------------------------

CREATE TABLE Clients(
        id_clients    Int  Auto_increment  NOT NULL ,
        Nom_client    Varchar (50) NOT NULL ,
        Prenom_client Varchar (50) NOT NULL ,
        id_MH         Int NOT NULL
	,CONSTRAINT Clients_PK PRIMARY KEY (id_clients)

	,CONSTRAINT Clients_Maitre_d_hotel_FK FOREIGN KEY (id_MH) REFERENCES Maitre_d_hotel(id_MH)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Table
#------------------------------------------------------------

CREATE TABLE Table(
        id_table      Int NOT NULL ,
        Nombre_Places Int NOT NULL ,
        id_clients    Int NOT NULL
	,CONSTRAINT Table_PK PRIMARY KEY (id_table)

	,CONSTRAINT Table_Clients_FK FOREIGN KEY (id_clients) REFERENCES Clients(id_clients)
	,CONSTRAINT Table_Clients_AK UNIQUE (id_clients)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Paiement
#------------------------------------------------------------

CREATE TABLE Paiement(
        id_paie    Int  Auto_increment  NOT NULL ,
        Montant    DECIMAL (15,3)  NOT NULL ,
        id_clients Int NOT NULL ,
        id_MH      Int NOT NULL
	,CONSTRAINT Paiement_PK PRIMARY KEY (id_paie)

	,CONSTRAINT Paiement_Clients_FK FOREIGN KEY (id_clients) REFERENCES Clients(id_clients)
	,CONSTRAINT Paiement_Maitre_d_hotel0_FK FOREIGN KEY (id_MH) REFERENCES Maitre_d_hotel(id_MH)
	,CONSTRAINT Paiement_Clients_AK UNIQUE (id_clients)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Chef cuisinier
#------------------------------------------------------------

CREATE TABLE Chef_cuisinier(
        id_cc     Int  Auto_increment  NOT NULL ,
        Nom_cc    Varchar NOT NULL ,
        Premon_cc Varchar NOT NULL
	,CONSTRAINT Chef_cuisinier_PK PRIMARY KEY (id_cc)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Commandes
#------------------------------------------------------------

CREATE TABLE Commandes(
        id_commande          Int  Auto_increment  NOT NULL ,
        Typecommande         Varchar (50) NOT NULL ,
        id_cc                Int NOT NULL ,
        id_cc_Chef_cuisinier Int NOT NULL
	,CONSTRAINT Commandes_PK PRIMARY KEY (id_commande)

	,CONSTRAINT Commandes_Chef_cuisinier_FK FOREIGN KEY (id_cc) REFERENCES Chef_cuisinier(id_cc)
	,CONSTRAINT Commandes_Chef_cuisinier0_FK FOREIGN KEY (id_cc_Chef_cuisinier) REFERENCES Chef_cuisinier(id_cc)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Plongeur
#------------------------------------------------------------

CREATE TABLE Plongeur(
        id_P  Int  Auto_increment  NOT NULL ,
        Nom_P Varchar (50) NOT NULL
	,CONSTRAINT Plongeur_PK PRIMARY KEY (id_P)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Outils_cuisine
#------------------------------------------------------------

CREATE TABLE Outils_cuisine(
        id_OC  Int  Auto_increment  NOT NULL ,
        Nom_OC Varchar (50) NOT NULL ,
        id_P   Int NOT NULL
	,CONSTRAINT Outils_cuisine_PK PRIMARY KEY (id_OC)

	,CONSTRAINT Outils_cuisine_Plongeur_FK FOREIGN KEY (id_P) REFERENCES Plongeur(id_P)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: Attribuer
#------------------------------------------------------------

CREATE TABLE Attribuer(
        id_table Int NOT NULL ,
        id_MH    Int NOT NULL,
	CONSTRAINT Attribuer_PK PRIMARY KEY (id_table,id_MH),
	CONSTRAINT Attribuer_Table_FK FOREIGN KEY (id_table) REFERENCES Table(id_table),
	CONSTRAINT Attribuer_Maitre_d_hotel0_FK FOREIGN KEY (id_MH) REFERENCES Maitre_d_hotel(id_MH)
);




	
