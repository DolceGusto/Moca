/* Requête écrite en Transact -SQL c'est pas la même que SQL classic  */
/*aide sur https://msdn.microsoft.com/fr-fr/library/cc879262(v=sql.120).aspx */
/*fichier à executer en premier suivi de celui des triggers ensuite celui des données */

CREATE TABLE PorteFeuille (
							id INT IDENTITY(1,1), /* IDENTITY(1,1) pour avoir un champ Auto increment*/
							designation VARCHAR(70),
							dateCreation DATETIME DEFAULT( getDate()) ,/*la date de creation ajourd'hui*/
							PRIMARY KEY(id)
							);

CREATE TABLE Utilisateur(
						   id INT IDENTITY(1,1),
						   idPorteFeuille INT NOT NULL, /* il doit appartenir à un et un seul portefeuille ???*/
						   nomDeCompte VARCHAR(30) NOT NULL,
						   nom VARCHAR(30) NOT NULL,
						   prenom VARCHAR(30) NOT NULL,
						   roleUtilisateur VARCHAR(30) NOT NULL CHECK (roleUtilisateur IN('createur', 'principal', 'normal')), /* les valeurs possible {"créateur","principal","normal"} */
						   FOREIGN KEY(idPorteFeuille) REFERENCES PorteFeuille(id) ON DELETE CASCADE,/* à la suppresion du portefeuille tous ses utilisateurs y sont supprimés*/
						   PRIMARY KEY(id)
						   );

CREATE TABLE Privilege(
							id INT IDENTITY(1,1),
							designation VARCHAR(70) NULL,
							PRIMARY KEY(id)
							);

CREATE TABLE PrivilegeUtilisateur(
							idUtilisateur INT NOT NULL,
							idPrivilege INT NOT NULL,
							dateCreation DATETIME DEFAULT (getdate()),
							FOREIGN KEY(idUtilisateur) REFERENCES Utilisateur(id) ON DELETE CASCADE,
							FOREIGN KEY(idPrivilege) REFERENCES Privilege(id) ON DELETE CASCADE,
							PRIMARY KEY(idUtilisateur,idPrivilege)
							);


CREATE TABLE Compte(
							id INT IDENTITY(1,1),
							idUtilisateur INT NOT NULL,
							solde float NOT NULL,
							designation VARCHAR(70) NOT NULL, /*il ne peut pas avoir deux comptes de même nom*/
							descript VARCHAR(140), /*description est un mot clé*/
							PRIMARY KEY(id),
							FOREIGN KEY(idUtilisateur) REFERENCES Utilisateur(id) ON DELETE CASCADE /*si un utilisateur est supprimé tous ses comptes seront supprimés*/
							);

CREATE TABLE Categorie(
							id INT IDENTITY(1,1),
							idPorteFeuille INT NOT NULL,
							designation VARCHAR(70) NOT NULL,
							descript VARCHAR(140),
							PRIMARY KEY (id),
							FOREIGN KEY(idPorteFeuille) REFERENCES PorteFeuille(id) ON DELETE CASCADE

							);

CREATE TABLE Transactions(		/*avec un "s" à la fin sinon mot clé de T-SQL*/
							id INT IDENTITY(1,1),
							idCompte INT NOT NULL,
							idCategorie INT NOT NULL, /*une et une seule catégorie*/
							montant float NOT NULL,
							dateCreation DATETIME DEFAULT( getDate()),
							designation VARCHAR(70), /*peut �tre null l'utilisateur a pas le temps*/
							typeTransact VARCHAR(10) NOT NULL CHECK (typeTransact IN('depense', 'entree')), /*valeur possible {"depense","entree"}*/
							FOREIGN KEY(idCompte) REFERENCES Compte(id) , /* pour supprimer un compter il faut supprimer toutes les transaction liés au compte*/
							FOREIGN KEY(idCategorie) REFERENCES Categorie(id) ,
							PRIMARY KEY(id,idCompte)

							);
CREATE TABLE TransactionPeriodique(

							id INT IDENTITY(1,1),
							idCompte INT NOT NULL,
							idCategorie INT NOT NULL,
							montant float NOT NULL,
							dateCreation DATETIME DEFAULT (getDate()),
							frequence INT NOT NULL, /* l'unité c'est le jour 1mois = 30 jours */
							designation VARCHAR(70),
							typeTransact VARCHAR(10) NOT NULL CHECK (typeTransact IN('depense', 'entree')), /*valeur possible {"depense","entree"}*/
							FOREIGN KEY(idCompte) REFERENCES Compte(id),
							FOREIGN KEY(idCategorie) REFERENCES Categorie(id),
							PRIMARY KEY(id,idCompte)

							);

CREATE TABLE Transfert(
							id INT IDENTITY(1,1),
							idCompteExpediteur INT NOT NULL,
							idCompteRecepteur INT NOT NULL,
							montant float NOT NULL,
							dateCreation DATETIME DEFAULT (getdate()),
							designation VARCHAR(70) NOT NULL,
							PRIMARY KEY(idCompteRecepteur,idCompteExpediteur,id),
							FOREIGN KEY(idCompteExpediteur) REFERENCES Compte(id),
							FOREIGN KEY(idCompteRecepteur) REFERENCES Compte(id),
							);
