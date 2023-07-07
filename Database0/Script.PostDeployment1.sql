/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--Add User
EXEC RegisterUser 'tristure','tristure@admin.com', 'test1234='
EXEC RegisterUser 'test','test@test.com', 'test1234='
EXEC RegisterUser 'bobby','boby@test.com', 'test1234='
EXEC RegisterUser 'johnny','johnny@test.com', 'test1234='
EXEC RegisterUser 'ninjaboy','ninja@boy.com', 'test1234='
EXEC RegisterUser 'samuraishark','samurai@shark.com', 'test1234='
EXEC RegisterUser 'huber','hu@bert.com', 'test1234='
EXEC RegisterUser 'tylerdurden','tyler@durden.com', 'test1234='
EXEC RegisterUser 'philip','philip@philip.com', 'test1234='
EXEC RegisterUser 'jean','je@an.com', 'test1234='
EXEC RegisterUser 'nicolasCage','nicolas@cage.com', 'test1234='
EXEC RegisterUser 'spike','spike@gmail.com', 'test1234='
EXEC RegisterUser 'hector','hector@gmail.com', 'test1234='
EXEC RegisterUser 'daemondeath','dd@gmail.com', 'test1234='

GO
--Asign Admin
UPDATE [dbo].[User] SET IsAdmin = 1
WHERE Id = 1
GO

INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (5,2);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (4,3);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (3,4);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (1,5);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (2,6);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (2,7);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (6,1);
INSERT INTO [dbo].[Friend](User_Id,Friend_Id) VALUES (8,2);

GO

--Set Success
INSERT INTO [dbo].[Success] ([Title], [Description], [ScoreMax],
[DeathNumber], [KillNumber], [BonusNumber], [WeaponNumber], [BulletDamage], 
[BossKill], [DragonKill], [SuccessRate], [Rank])
VALUES
--Title        -Description   -ScrM-
('Le Début de la Gloire', 'Atteindre un score de 1000', 1000, 0, 0, 0, 0, 0, 0, 0, 0, 'F'),
('Champion en Herbe', 'Atteindre un score de 2500', 2500, 0, 0, 0, 0, 0, 0, 0, 0, 'E'),
('Mercenaire', 'Atteindre un score de 5000', 5000, 0, 0, 0, 0, 0, 0, 0, 0, 'D'),
('Soldat', 'Atteindre un score de 10000', 10000, 0, 0, 0, 0, 0, 0, 0, 0, 'B'),
('Puissant', 'Atteindre un score de 15000', 15000, 0, 0, 0, 0, 0, 0, 0, 0, 'A'),
('Increvable', 'Atteindre un score de 20000', 20000, 0, 0, 0, 0, 0, 0, 0, 0, 'S'),
('Apprentissage', 'Mourrir au moins 10 fois', 0, 10, 0, 0, 0, 0, 0, 0, 0, 'F'),
('Le Gout du Sang', 'Abatre au moins 10 opposant', 0, 0, 10, 0, 0, 0, 0, 0, 0, 'F'),
('Gourmand va !', 'Ramasser 10 Bonus', 0, 0, 0, 10, 0, 0, 0, 0, 0, 'D'),
('Tacticien', 'Ramasser 10 Amelioration', 0, 0, 0, 0, 10, 0, 0, 0, 0, 'D'),
('Simplement Humain', 'vous vous etes fait toucher 10 fois', 0, 0, 0, 0, 0, 10, 0, 0, 0, 'F'),
('Espoir', 'Vaincre 1 Boss', 0, 0, 0, 0, 0, 0, 1, 0, 0, 'B'),
('Hero', 'Vaincre 2 Boss', 0, 0, 0, 0, 0, 0, 2, 0, 0, 'A')
