CREATE PROCEDURE [dbo].[CheckEmail]
	@thisEmail VARCHAR(50)
AS
BEGIN
	DECLARE @Email VARCHAR(50)
	DECLARE cursorCheck CURSOR FOR
	SELECT [Email] FROM [dbo].[User]
	OPEN cursorCheck
	FETCH NEXT FROM cursorCheck INTO @Email;
		WHILE @@FETCH_STATUS = 0
		BEGIN
		-- Effectuez la comparaison avec la variable spécifique
		IF @Email = @thisEmail
			BEGIN
				-- Faites quelque chose si la correspondance est trouvée
				RAISERROR ('Email invalide', 16, 1);
				PRINT 'Correspondance trouvée pour Email = ' + CAST(@Email AS VARCHAR(50));
				RETURN 3;
			END
		FETCH NEXT FROM cursorCheck INTO @Email;
		END
END
RETURN 0



--1. La clause "CREATE PROCEDURE" est utilisée pour définir une nouvelle procédure stockée dans la base de données.
--2. "[dbo].[CheckEmail]" est le nom de la procédure stockée.
--3. "@thisEmail VARCHAR(50)" est le paramètre d'entrée de la procédure stockée, qui attend une valeur de type VARCHAR avec une longueur maximale de 50 caractères.
--4. "AS BEGIN" marque le début du bloc de code de la procédure stockée.
--5. "DECLARE @Email VARCHAR(50)" déclare une variable locale appelée "@Email" pour stocker les valeurs des emails de la table.
--6. "DECLARE cursorCheck CURSOR FOR" déclare un curseur nommé "cursorCheck" pour parcourir les résultats de la requête SELECT.
--7. "SELECT [Email] FROM [dbo].[User]" est la requête SELECT qui récupère tous les emails de la table "User" dans le schéma "dbo".
--8. "OPEN cursorCheck" ouvre le curseur.
--9. "FETCH NEXT FROM cursorCheck INTO @Email" récupère la première ligne du curseur et stocke la valeur de la colonne "Email" dans la variable "@Email".
--10. La boucle "WHILE @@FETCH_STATUS = 0" itère tant qu'il y a des lignes à récupérer du curseur.
--11. "IF @Email = @thisEmail" compare la valeur de la variable "@Email" avec la valeur du paramètre "@thisEmail".
--12. Si la correspondance est trouvée, la procédure stockée affiche un message avec l'email correspondant à l'aide de l'instruction "PRINT", génère une erreur avec "RAISERROR", et retourne la valeur 3.
--13. "FETCH NEXT FROM cursorCheck INTO @Email" récupère la ligne suivante du curseur.
--14. La boucle se répète jusqu'à ce qu'il n'y ait plus de lignes à récupérer du curseur.
--15. "END" marque la fin du bloc de code de la procédure stockée.
--16. "RETURN 0" retourne la valeur 0 pour indiquer que la procédure s'est exécutée avec succès.

--En résumé, cette procédure stockée parcourt la table "User" pour vérifier si 
--l'email spécifié dans le paramètre "@thisEmail" correspond à un email existant 
--dans la table. Si une correspondance est trouvée, un message est affiché et une 
--erreur est générée. La procédure stockée retourne 3 dans ce cas. Sinon, la procédure 
--stockée se termine normalement et retourne 0.
