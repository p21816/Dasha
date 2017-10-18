--WITH DirectReports (id1, id2, [Level], [route] , [sum])
--AS
--(
---- Anchor member definition
--    SELECT e.id1, e.id2, 0 AS [Level], cast( CONCAT(e.id1,'-', e.id2) as nvarchar(MAX)) [route], distance as [sum]
--    FROM dbo.roads AS e
--    WHERE id1 = 1
--    UNION ALL
---- Recursive member definition
--    SELECT e.id1, e.id2, [Level] + 1 , CONCAT(d.[route], '-', e.id2), [sum] = distance + [sum]
--    FROM dbo.roads AS e
--    INNER JOIN DirectReports AS d
--        ON e.id1 = d.id2 
--		    WHERE [Level] < 7
--)
---- Statement that executes the CTE
--SELECT TOP(1) * FROM DirectReports
--where id2 = 3
--ORDER BY [sum]

--CREATE VIEW v as 

WITH DirectReports (id1, id2, [Level], [route] , [sum])
AS
(
-- Anchor member definition
    SELECT e.id1, e.id2, 0 AS [Level], cast( CONCAT(e.id1,'-', e.id2) as nvarchar(MAX)) [route], distance as [sum]
    FROM dbo.oneWayRoads AS e
    UNION ALL
-- Recursive member definition
    SELECT e.id1, e.id2, [Level] + 1 , CONCAT(d.[route], '-', e.id2), [sum] = distance + [sum]
    FROM dbo.oneWayRoads AS e
    INNER JOIN DirectReports AS d
        ON e.id1 = d.id2 
		    WHERE [Level] < 7
)
-- Statement that executes the CTE
SELECT  * FROM DirectReports


SELECT id1, id2 , MAX ([sum]) FROM v
GROUP BY id1, id2
ORDER BY MAX ([sum]) DESC