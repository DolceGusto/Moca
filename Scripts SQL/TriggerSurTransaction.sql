/*utilisation des trigger pour la gestion des requête DML sur la table Transation */
-- to do : la même chose pour la table TransactionPlanifié

/*directive :
	- utiliser les variable local DECLARE @var = type 
	- utiliser les deux tables INSERTED qui contien la nouvelle ligne inserer la même structure que l'autre 
	  DELETED qui contient les ligne supprimées depuis le declenchement du trigger
	  lien https://social.msdn.microsoft.com/Forums/sqlserver/en-US/11b470c2-fde7-4aeb-b1b3-a3768a91e350/how-to-get-old-value-while-writting-after-update-trigger?forum=transactsql
*/
CREATE TRIGGER afterInsertTransaction
ON Transactions
AFTER INSERT
AS

/*implementatino du corp*/

GO

CREATE TRIGGER afterUpdateTransaction
ON Transactions
AFTER UPDATE
AS
 /*implementation du corp */

Go

CREATE TRIGGER afterDeleteTransaction
ON Transactions
AFTER DELETE
AS


GO