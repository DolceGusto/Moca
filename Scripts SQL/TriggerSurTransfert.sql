CREATE TRIGGER afterInsertTransfert
ON Transfert
AFTER INSERT
AS


	DECLARE @idCompteExpediteur INT ;
	DECLARE @idCompteRecepteur INT ;
	DECLARE @montant FLOAT ;

	DECLARE insertedCursor CURSOR LOCAL
	FOR SELECT idCompteRecepteur,idCompteExpediteur,montant
		FROM INSERTED ;

	OPEN insertedCursor ;
	FETCH NEXT FROM insertedCursor INTO @idCompteRecepteur, @idCompteExpediteur, @montant ;

	WHILE @@FETCH_STATUS = 0 
		BEGIN

			UPDATE compte 
			SET solde = solde - @montant
			WHERE id = @idCompteExpediteur ;

			UPDATE compte 
			SET solde = solde + @montant
			WHERE id = @idCompteRecepteur ;

			FETCH NEXT FROM insertedCursor INTO @idCompteRecepteur, @idCompteExpediteur, @montant ;

		END;

	CLOSE insertedCursor ;
	DEALLOCATE insertedCursor;
GO

CREATE TRIGGER afterDeleteTransfert
ON Transfert
AFTER DELETE
AS


	DECLARE @idCompteExpediteur INT ;
	DECLARE @idCompteRecepteur INT ;
	DECLARE @montant FLOAT ;

	DECLARE deletedCursor CURSOR LOCAL
	FOR SELECT idCompteRecepteur,idCompteExpediteur,montant
		FROM DELETED ;

	OPEN deletedCursor ;
	FETCH NEXT FROM deletedCursor INTO @idCompteRecepteur, @idCompteExpediteur, @montant ;

	WHILE @@FETCH_STATUS = 0 
		BEGIN

			UPDATE compte 
			SET solde = solde + @montant
			WHERE id = @idCompteExpediteur ;

			UPDATE compte 
			SET solde = solde - @montant
			WHERE id = @idCompteRecepteur ;

			FETCH NEXT FROM deletedCursor INTO @idCompteRecepteur, @idCompteExpediteur, @montant ;

		END;

	CLOSE deletedCursor ;
	DEALLOCATE deletedCursor;
GO


CREATE TRIGGER afterUpdateTransfert
ON Transfert
AFTER UPDATE
AS


	DECLARE @ancienIdCompteExpediteur INT ;
	DECLARE @ancienIdCompteRecepteur INT ;
	DECLARE @ancienMontant FLOAT ;
	DECLARE @nouveauIdCompteExpediteur INT ;
	DECLARE @nouveauIdCompteRecepteur INT ;
	DECLARE @nouveauMontant FLOAT ;

	DECLARE insertedDeletedCursor CURSOR LOCAL
	FOR SELECT DELETED.idCompteRecepteur AS ancienIdCompteRecepteur,DELETED.idCompteExpediteur AS ancienIdCompteExpediteur,DELETED.montant AS ancienMontant,
			   INSERTED.idCompteRecepteur AS nouveauIdCompteRecepteur, INSERTED.idCompteExpediteur AS nouveauIdCompteExpediteur, INSERTED.montant AS nouveauMontant
		FROM DELETED
			 JOIN INSERTED
			 ON (DELETED.id = INSERTED.id) ;

	OPEN insertedDeletedCursor ;
	FETCH NEXT FROM insertedDeletedCursor INTO @ancienIdCompteRecepteur, @ancienIdCompteExpediteur, @ancienMontant,
					   						  @nouveauIdCompteRecepteur, @nouveauIdCompteExpediteur, @nouveauMontant ;


	WHILE @@FETCH_STATUS = 0 
		BEGIN

			IF @ancienIdCompteExpediteur != @nouveauIdCompteExpediteur  /*changement dans l'expediteur*/
			 BEGIN

			 	UPDATE compte
			 	SET solde = solde + @ancienMontant
			 	WHERE id = @ancienIdCompteExpediteur ;

			 	UPDATE compte
			 	SET solde = solde - @nouveauMontant
			 	WHERE id= @nouveauIdCompteExpediteur ;


			 END;
		    IF @ancienIdCompteRecepteur!= @nouveauIdCompteRecepteur /*changement dans le recepteur  */
			 BEGIN

			 	UPDATE compte
			 	SET solde = solde -@ancienMontant 
			 	WHERE id = @ancienIdCompteRecepteur ; --update de l'ancien compte recepteur 

			 	UPDATE compte 
			 	SET solde = solde +@nouveauMontant
			 	WHERE id = @nouveauIdCompteRecepteur ; --update du nouveau compte recepteur 

			 END;
			ELSE IF @ancienMontant != @nouveauMontant /*changment seulement dans le montant */
			 BEGIN

			 	UPDATE compte
			 	SET solde = solde + @ancienMontant -@nouveauMontant
			 	WHERE id = @nouveauIdCompteExpediteur ;

			 	UPDATE compte
			 	SET solde = solde - @ancienMontant + @nouveauMontant
			 	WHERE id = @nouveauIdCompteRecepteur ; 

			 END ;

			

			FETCH NEXT FROM insertedDeletedCursor INTO @ancienIdCompteRecepteur, @ancienIdCompteExpediteur, @ancienMontant,
					   						  @nouveauIdCompteRecepteur, @nouveauIdCompteExpediteur, @nouveauMontant ;
		END;

	CLOSE insertedDeletedCursor ;
	DEALLOCATE insertedDeletedCursor;
GO