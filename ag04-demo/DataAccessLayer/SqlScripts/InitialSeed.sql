SET IDENTITY_INSERT GameStatus ON

INSERT INTO GameStatus(Id, CreatedUTC, ModifiedUTC, [Name])
VALUES 
	(1, GETUTCDATE(), GETUTCDATE(), 'In Progress'),
	(2, GETUTCDATE(), GETUTCDATE(), 'Done');

SET IDENTITY_INSERT GameStatus OFF

SET IDENTITY_INSERT ShipType ON

INSERT INTO ShipType(Id, CreatedUTC, ModifiedUTC, [Name], NumberOfPoints)
VALUES 
	(1, GETUTCDATE(), GETUTCDATE(), 'Patrol Craft', 1),
	(2, GETUTCDATE(), GETUTCDATE(), 'Submarine', 2),
	(3, GETUTCDATE(), GETUTCDATE(), 'Destroyer', 3),
	(4, GETUTCDATE(), GETUTCDATE(), 'Battleship', 4);

SET IDENTITY_INSERT ShipType OFF