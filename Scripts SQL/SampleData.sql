/*executer en 3*/

INSERT INTO PorteFeuille(designation)
VALUES ('famille Doe'),
	   ('famille Smith') ;

INSERT INTO Utilisateur(idPorteFeuille,nomDeCompte,nom,prenom,roleUtilisateur)
VALUES  (1,'johnDoe@hotmail.com','Doe','John','createur'),
		(1,'janeDoe@hotmail.com','Doe','Jane','normal'),
		(1,'bobyDoe@htomail.com','Doe','boby','normal'),
		(1,'lindseyDoe@hotmail.com','Doe','lindsey','normal'),
		(2,'samSmit@hotmail.com','Smith','sam','createur') ; /*porte feuille à lui seul*/


INSERT INTO Categorie(idPorteFeuille,designation,descript)
VALUES  (1,'transport','le cout des transport'),--1
		(1,'sante','les depense liées à la santé'),--2
		(1,'course','les courses journalières'),--3
		(1,'divers','les autres type de courses'),--4
		(2,'divers','les autres type de courses');--5 /*la seul categorie de la famille smith*/



INSERT INTO Privilege(designation)
VALUES  ('creation de categorie'),
		('voir les stats'),
		('ajouter des amis') ;

INSERT INTO PrivilegeUtilisateur(idUtilisateur,idPrivilege)
VALUES (1,1),(1,2),(1,3) ; /*tout les droits pour johnDoe*/

INSERT INTO compte(idUtilisateur,solde,designation,descript)
VALUES (1,10000,'espece','compte par defaut'),--1
	   (2,10000,'espece','compte par defaut'),--2
	   (3,10000,'espece','compte par defaut'),--3
	   (4,10000,'espece','compte par defaut'),--4
	   (5,10000,'espece','compte par defaut'),--5 /*compte espece de sam smith*/
	   (1,10000,'compte Bancaire','le compte en banque de john doe'),--6 /*compte banquaire de papa doe*/
	   (5,20000,'compte ccp ','compte ccp de sam smith') ;--7 /* compte ccp de papa smith*/


INSERT INTO Transactions(idCompte,idCategorie,montant,typeTransact)
VALUES (1,4,50,'depense'),
	   (1,4,50,'depense'),
	   (1,4,150,'depense'),
	   (1,4,100,'depense'),
	   (1,4,75,'entree'),
	   (1,4,25,'entree'),
	   (1,4,5,'entree'),
	   (2,4,25,'depense'),
	   (3,4,25,'depense'),
	   (4,4,25,'depense'),
	   (2,4,50,'entree'),
	   (3,4,50,'entree'),
	   (4,4,150,'entree'),
	   (6,4,100,'entree'),
	   (5,4,50,'depense'),
	   (5,4,50,'depense'),
	   (5,4,150,'depense'),
	   (7,4,100,'depense'),
	   (7,4,75,'entree'),
	   (7,4,25,'entree'),
	   (5,4,5,'entree') ;

INSERT INTO transfert(idCompteExpediteur,idCompteRecepteur,montant,designation)
VALUES (1,6,150,'mettre du pognon à la banque'),
	   (1,2,100,'pour Jane'),
	   (1,3,25,'pour boby'),
	   (1,4,10,'pour lindsey'),
	   (2,3,75,'pour boby'),
	   (2,4,100,'pour lindsey');


