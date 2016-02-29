/*executer en 2*/

CREATE TRIGGER afterInsertTransaction
ON Transactions
AFTER INSERT
AS
	
	DECLARE @montant FLOAT;
	DECLARE @typeTransaction VARCHAR(30);
	DECLARE @idCompte INT;

	DECLARE insertedCursor CURSOR LOCAL
	FOR 
		SELECT montant,typeTransact,idCompte
		FROM INSERTED ;

	OPEN insertedCursor ;
	FETCH NEXT FROM insertedCursor INTO @montant, @typeTransaction, @idCompte ;

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		 UPDATE compte
		 SET solde = solde + 
		 					CASE
		 						 WHEN @typeTransaction = 'depense' THEN -@montant
		 						 WHEN @typeTransaction = 'entree'  THEN @montant
	-	 					END
		 WHERE id = @idCompte ;
		FETCH NEXT FROM insertedCursor INTO @montant, @typeTransaction, @idCompte ;		
	END;

	CLOSE insertedCursor ;
	DEALLOCATE insertedCursor ;
	 
GO

CREATE TRIGGER afterUpdateTransaction
ON Transactions
AFTER UPDATE
AS
 
 DECLARE @montant FLOAT ;
 DECLARE @ancienMontant FLOAT ;
 DECLARE @nouveauMontant FLOAT ;
 DECLARE @ancienIdCompte INT ;
 DECLARE @nouveauIdCompte INT ;
 DECLARE @ancienTypeTransaction  VARCHAR(30);
 DECLARE @nouveauTypeTransaction VARCHAR(30) ;

 	/*declaration d'un curseur pour l'iteration au traveres des lignes des deux tables DELETED et INSERTED*/
 	DECLARE insertedDeletedCursor CURSOR LOCAL
 	FOR 
 		SELECT INSERTED.montant AS nouveauMontant, INSERTED.typeTransact AS nouveauTypeTransaction,
 			   INSERTED.idCompte AS nouveauIdCompte,
 			   DELETED.montant AS ancienMontant, DELETED.typeTransact AS ancienTypeTransaction,
 			   DELETED.idCompte AS ancienIdCompte 
 		FROM INSERTED 
 			 INNER JOIN
 			 DELETED ON (DELETED.id = INSERTED.id) ;

 	OPEN insertedDeletedCursor ;

 	FETCH NEXT FROM insertedDeletedCursor  INTO @nouveauMontant, @nouveauTypeTransaction, @nouveauIdCompte,
 												@ancienMontant, @ancienTypeTransaction, @ancienIdCompte ;

 	WHILE @@FETCH_STATUS = 0
 	BEGIN
 			/*affectation des variables locales*/


		 	IF @nouveauIdCompte != @ancienIdCompte /*changement dans le compte id*/
		 	   	BEGIN
		 	   		IF @nouveauTypeTransaction = 'depense'
		 	   		   SET @montant = -@nouveauMontant ;
		 	   		ELSE
		 	   			SET @montant = @nouveauMontant ;

		 	   		UPDATE compte
		 	   		SET solde = solde + @montant 
		 	   		WHERE id = @nouveauIdCompte ;

		 	   		IF @ancienTypeTransaction = 'entree'
		 	   		   SET @montant = -@ancienMontant ;
		 	   		ELSE
		 	   		   SET @montant = @ancienMontant;

		 	   		UPDATE compte
		 	   		SET solde = solde + @montant
		 	   		WHERE id = @ancienIdCompte ;

		 	   	END;
		 	ELSE IF @ancienTypeTransaction != @nouveauTypeTransaction /*changement dans le type de transaction PAS dans le compte id */
		 		BEGIN

		 			IF @nouveauTypeTransaction = 'depense'
		 				SET @montant = - @ancienMontant - @nouveauMontant ;
		 			ELSE 
		 				SET @montant = @ancienMontant + @nouveauMontant ;

		 			UPDATE compte
		 			SET solde = solde + @montant
		 			WHERE id = @nouveauIdCompte  ;


		 		END;
		 	ELSE IF @ancienMontant != @nouveauMontant /*changement JUSTE dans le montant de la transaction */
		 		BEGIN

		 			IF @nouveauTypeTransaction = 'depense' 
		 			   SET @montant = @nouveauMontant - @ancienMontant ;
		 			ELSE 
		 			   SET @montant = @ancienMontant - @nouveauMontant ;

		 			 UPDATE compte
		 			 SET solde = solde - @montant
		 			 WHERE id = @nouveauIdCompte ;
		 		END;

			FETCH NEXT FROM insertedDeletedCursor  INTO @nouveauMontant, @nouveauTypeTransaction, @nouveauIdCompte,
 												@ancienMontant, @ancienTypeTransaction, @ancienIdCompte ;
	END;

	CLOSE insertedDeletedCursor ;
	DEALLOCATE insertedDeletedCursor ;
Go

CREATE TRIGGER afterDeleteTransaction
ON Transactions
AFTER DELETE
AS

	DECLARE @montant FLOAT;
	DECLARE @typeTransaction VARCHAR(30);
	DECLARE @idCompte INT;

	DECLARE deletedCursor CURSOR LOCAL
	FOR 
		SELECT montant,typeTransact,idCompte
		FROM DELETED ;

	OPEN deletedCursor ;
	FETCH NEXT FROM deletedCursor INTO @montant, @typeTransaction, @idCompte ;

	WHILE @@FETCH_STATUS = 0
	BEGIN
	
		 UPDATE compte
		 SET solde = solde + 
		 					CASE
		 						 WHEN @typeTransaction = 'depense' THEN @montant
		 						 WHEN @typeTransaction = 'entree'  THEN -@montant
	-	 					END
		 WHERE id = @idCompte ;
		FETCH NEXT FROM deletedCursor INTO @montant, @typeTransaction, @idCompte ;		
	END;

	CLOSE deletedCursor ;
	DEALLOCATE deletedCursor ;

GO