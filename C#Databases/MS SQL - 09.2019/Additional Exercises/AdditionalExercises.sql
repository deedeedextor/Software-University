---Problem 1
SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider],
       COUNT(*) AS [Number Of Users]
FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email))
ORDER BY [Number Of Users] DESC, [Email Provider]

---Problem 2
SELECT g.[Name] AS [Game],
       gt.[Name] AS [Game Type],
	   u.Username AS [Username],
	   ug.[Level] AS [Level],
	   ug.Cash AS [Cash],
	   c.[Name] AS [Character]
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Characters AS c ON c.Id = ug.CharacterId
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
ORDER BY [Level] DESC, [Username], [Game]

---Problem 3
SELECT u.Username AS [Username],
       g.[Name] AS [Game],
	   COUNT(ugi.ItemId) AS [Items Count],
	   SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames AS ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
GROUP BY u.Username, g.[Name]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, [Username]

---Problem 6
SELECT i.[Name] AS [Item],
       i.[Price],
	   i.[MinLevel],
	   gt.[Name] AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtf ON gtf.ItemId = i.Id
LEFT JOIN GameTypes AS gt ON gt.Id = gtf.GameTypeId
ORDER BY [Forbidden Game Type] DESC, [Item]

---Problem 8
SELECT p.[PeakName],
       m.[MountainRange],
	   p.[Elevation]
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
ORDER BY p.Elevation DESC, p.PeakName

---Problem 9
SELECT p.[PeakName],
       m.MountainRange AS [Mountain],
	   c.[CountryName],
	   co.[ContinentName]
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
JOIN MountainsCountries AS mc ON mc.MountainId = m.Id
JOIN Countries AS c ON c.CountryCode = mc.CountryCode
JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
ORDER BY p.PeakName, c.CountryName

---Problem 10
SELECT [c].[CountryName] AS [CountryName],
          [c2].[ContinentName] AS [ContinentName],
  	      COUNT([cr].[RiverId]) AS [RiversCount],
		  CASE
			 WHEN COUNT([cr].[RiverId]) = 0 THEN 0
			 ELSE SUM([r].[Length])
  	      END AS [TotalLength]
     FROM [dbo].[Countries] AS c
LEFT JOIN [dbo].[Continents] AS [c2] ON [c].[ContinentCode] = [c2].[ContinentCode]
LEFT JOIN [dbo].[CountriesRivers] AS [cr] ON [c].[CountryCode] = [cr].[CountryCode]
LEFT JOIN [dbo].[Rivers] AS [r] ON [cr].[RiverId] = [r].[Id]
 GROUP BY [c].[CountryName], [c2].[ContinentName]
 ORDER BY [RiversCount] DESC, [TotalLength] DESC, [CountryName];

 ---Problem 11
 SELECT cu.[CurrencyCode],
        cu.[Description] AS [Currency],
		COUNT(c.CountryCode) AS [NumberOfCountries]
 FROM Currencies AS cu
 LEFT JOIN Countries AS c ON c.CurrencyCode = cu.CurrencyCode
 GROUP BY cu.CurrencyCode, cu.[Description]
 ORDER BY [NumberOfCountries] DESC, [Description]

 ---Problem 12
 SELECT co.[ContinentName],
        SUM(CAST(c.AreaInSqKm AS BIGINT)) AS [CountriesArea],
		SUM(CAST(c.[Population] AS BIGINT)) AS [CountriesPopulation]
 FROM Countries AS c
 JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
 GROUP BY co.ContinentName
 ORDER BY [CountriesPopulation] DESC

 ---Problem 13
 CREATE TABLE Monasteries(
 Id INT PRIMARY KEY IDENTITY NOT NULL,
 [Name] VARCHAR(50) NOT NULL,
 CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
 )

 INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted VARCHAR(10) DEFAULT('false') NOT NULL

UPDATE Countries
SET IsDeleted = 'true'
WHERE CountryCode IN (SELECT c.CountryCode FROM Countries AS C
                      JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
					  GROUP BY  c.CountryCode
					  HAVING COUNT(cr.RiverId) > 3)

SELECT m.[Name] AS [Monastery],
       c.CountryName AS[Country] 
FROM Monasteries AS m
JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 'false'
ORDER BY m.[Name] 

---Problem 14
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries ([Name], CountryCode) VALUES
('Hanga Abbey', 'TZ')

INSERT INTO Monasteries ([Name], CountryCode) VALUES
('Myin-Tin-Daik', NULL)

SELECT co.[ContinentName],
       c.[CountryName],
	   COUNT(m.Id) AS [MonasteriesCount] 
FROM Countries AS c
JOIN Continents AS co ON co.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries AS m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 'false'
GROUP BY [ContinentName], [CountryName]
ORDER BY [MonasteriesCount] DESC, [CountryName]
