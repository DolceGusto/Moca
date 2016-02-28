CREATE TRIGGER afterInsertTransaction
ON Transactions
AFTER INSERT
AS

 
 DECLARE @montantTransaction FLOAT;
 DECLARE @idCompte INT;

	 SELECT  @idCompte = INSERTED.idCompte, @montantTransaction = INSERTED.montant
	 FROM INSERTED;

	 UPDATE  compte
	 SET solde = solde - @montantTransaction
	 WHERE id = @idCompte ;

GO

CREATE TRIGGER afterUpdateTransaction
ON Transactions
AFTER UPDATE
AS
 
 DECLARE @ancienMontantTransaction FLOAT ;
 DECLARE @nouveauMontantTransaction FLOAT ;
 DECLARE @idCompte INT ;
 DECLARE @difference FLOAT ;

 	SELECT @ancienMontantTransaction = DELETED.montant, @idCompte = DELETED.idCompte
 	FROM DELETED;

 	SELECT @nouveauMontantTransaction = INSERTED.montant
 	FROM INSERTED ;

 	SET @difference =  @nouveauMontantTransaction - @ancienMontantTransaction ;
 	 /* verifier la syntax relative à T-SQL */
 	IF(@difference = 0)
	BEGIN
 		UPDATE  compte
 		SET compte.solde = compte.solde - @difference
 		WHERE compte.id = @idCompte ;

 	END
 	


Go

CREATE TRIGGER afterDeleteTransaction
ON Transactions
AFTER DELETE
AS

DECLARE @montantTransaction FLOAT ;
DECLARE @idCompte INT ;

	SELECT @idCompte = DELETED.idCompte, @montantTransaction = DELETED.montant 
	FROM DELETED ;

	UPDATE compte
	SET compte.solde = compte.solde +  @montantTransaction
	WHERE compte.id = @idCompte ;

GO