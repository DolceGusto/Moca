/* Requête ecrite en Transact -SQL c'est pas la même que SQL classic  */
/*aide sur https://msdn.microsoft.com/fr-fr/library/cc879262(v=sql.120).aspx */

CREATE TABLE PorteFeuille (
							id INT IDENTITY, /* IDENTITY pour avoir un champ Auto increment*/
							designation VARCHAR(70),
							dateCreation DATETIME DEFAULT( getDate()) ,/*la date de creation ajourd'hui*/
							PRIMARY KEY(id)
							) ;

CREATE TABLE Utilisateur( 
						   id INT IDENTITY,
						   idPorteFeuille INT NOT NULL, /* il doit appartenir à un et un seul portefeuille ???*/
						   nomDeCompte VARCHAR(30) NOT NULL,
						   nom VARCHAR(30) NOT NULL,
						   prenom VARCHAR(30) NOT NULL,
						   roleUtilisateur VARCHAR(30), /* les valeurs possible {"créateur","principal","normal"} */
						   PRIMARY KEY(id),
						   FOREIGN KEY(idPorteFeuille) REFERENCES PorteFeuille(id) 
						   ) ;
CREATE TABLE Privilege(
							id INT IDENTITY,
							designation VARCHAR(70) NOT NULL,
							PRIMARY KEY(id)
							);

CREATE TABLE PrivilegeUtilisateur(
							id INT IDENTITY,
							idUtilisateur INT NOT NULL,
							idPrivilege INT NOT NULL,
							PRIMARY KEY(id),
							FOREIGN KEY(idUtilisateur) REFERENCES Utilisateur(id),
							FOREIGN KEY(idPrivilege) REFERENCES Privilege(id)
							);
CREATE TABLE Compte(
							id INT IDENTITY,
							idUtilisateur INT NOT NULL,
							solde INT NOT NULL,
							designation VARCHAR(70) NOT NULL,
							descript VARCHAR(140), /*description est un mot clé*/
							PRIMARY KEY(id),
							FOREIGN KEY(idUtilisateur) REFERENCES Utilisateur(id)
							);

CREATE TABLE Categorie(
							id INT IDENTITY,
							designation VARCHAR(70) NOT NULL,
							descript VARCHAR(140),
							PRIMARY KEY (id)

							);

CREATE TABLE Transactions(		/*avec un "s" à la fin sinon mot clé de T-SQL*/
							id INT IDENTITY,
							idCompte INT NOT NULL,
							idCategorie INT NOT NULL, /*une et une seule catégorie*/
							montant INT NOT NULL,
							dateCreation DATETIME DEFAULT( getDate()),
							designation VARCHAR(70), /*peut être null l'utilisateur a pas le temps*/
							typeTransact VARCHAR(10) NOT NULL, /*valeur possible {"depense","sortie"}*/
							PRIMARY KEY(id),
							FOREIGN KEY(idCompte) REFERENCES Compte(id),
							FOREIGN KEY(idCategorie) REFERENCES Categorie(id)

							);
CREATE TABLE TransactionPeriodique(
							id INT IDENTITY,
							idCompte INT NOT NULL,
							idCategorie INT NOT NULL,
							montant INT NOT NULL,
							dateCreation DATETIME DEFAULT (getDate()),
							frequence INT NOT NULL, /* l'unité c'est le jour 1mois = 30 jours */
							designation VARCHAR(70),
							typeTransact VARCHAR(10) NOT NULL,
							PRIMARY KEY(id),
							FOREIGN KEY(idCompte) REFERENCES Compte(id),
							FOREIGN KEY(idCategorie) REFERENCES Categorie(id)
							);
CREATE TABLE Transfert(
							id INT IDENTITY,
							idCompteExpediteur INT NOT NULL,
							idCompteRecepteur INT NOT NULL,
							montant INT NOT NULL,
							dateCreation DATETIME DEFAULT (getdate()),
							designation VARCHAR(70) NOT NULL,
							PRIMARY KEY(id),
							FOREIGN KEY(idCompteExpediteur) REFERENCES Compte(id),
							FOREIGN KEY(idCompteRecepteur) REFERENCES Compte(id)
);