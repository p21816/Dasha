---------- ЗАДАНИЕ 1 ----------

--сколько телефонов у каждого человека:
SELECT FirstName, count(phone) as [numberOfPhones]  FROM People LEFT JOIN Phones ON Phones.people_id = People.Id
GROUP BY FirstName

--сколько в среднем телефонов у людей:
SELECT ((SELECT COUNT(phone) FROM Phones) / (SELECT COUNT(Id) FROM People))

--найти людей, у которых число телефонов меньше, чем средее:
SELECT FirstName, [numberOfPhones] FROM (SELECT FirstName, count(phone) as [numberOfPhones]  FROM People LEFT JOIN Phones ON Phones.people_id = People.Id
GROUP BY FirstName) tbl WHERE [numberOfPhones] < (SELECT ((SELECT COUNT(phone) FROM Phones) / (SELECT COUNT(Id) FROM People)))

--есть ли в таблице семизначные номера телефонов, представляющие собой палиндром:
SELECT phone AS 'Palindrom' FROM Phones WHERE LEN(phone) = 7
 AND ( SUBSTRING(phone, 1 , 1) = SUBSTRING(phone, 7 , 1))
 AND ( SUBSTRING(phone, 2 , 1) = SUBSTRING(phone, 6 , 1))
 AND ( SUBSTRING(phone, 3 , 1) = SUBSTRING(phone, 5 , 1))



 ---------- ЗАДАНИЕ 2 ----------

--удалить все не цифровые символы в номере телефона:
DECLARE @S VARCHAR(100);
SET @S = (select phone from Phones WHERE phone LIKE '%[^0-9]%')
WHILE @S LIKE '%[^0-9]%' SET @S=STUFF(@S,PATINDEX('%[^0-9]%',@S),1,'');
SELECT @S;

SELECT phone FROM Phones

--дополнить все телефоны до 12 цифр нулями слева:
UPDATE Phones SET phone = REPLICATE ('0', (12 - LEN(phone)) ) + phone
WHERE LEN(phone) < 12

SELECT phone FROM Phones

--дополнить все телефоны до 12 цифр слева последовательностью 375297654321
UPDATE Phones SET phone = STUFF('375297654321', (13 - LEN(phone)) , LEN(phone), '' ) + phone  FROM Phones
SELECT phone FROM Phones

--добавить булевскую колонку в таблицу, для телефонов, присутстсвующий в таблице более одного раза
-- записать туда 1, для уникальных - ноль

ALTER TABLE Phones ADD uniquePhone bit NULL ;
UPDATE Phones SET uniquePhone = 0

UPDATE Phones SET uniquePhone = 1 WHERE phone =  (
SELECT phone  FROM Phones
GROUP BY phone
HAVING COUNT(*) > 1)



---------- ЗАДАНИЕ 3 ----------
-- сколько друзей у каждого человека
SELECT id1 , COUNT(*) AS [numberOfFriends] FROM TransitiveFriendship
GROUP BY id1

-- сколько друзей у каждого человека в среднем
SELECT  SUM([numberOfFriends]) /  COUNT(id1) FROM (SELECT id1 , COUNT(*)  AS [numberOfFriends]  FROM TransitiveFriendship
GROUP BY id1) tbl 

--медиану количества друзей
SELECT TOP (1)  mediana AS 'у стольки человек', numberOfFriends AS 'такое число друзей'
 FROM (SELECT numberOfFriends, COUNT (numberOfFriends) AS mediana
 FROM (SELECT id1 , COUNT(*) AS [numberOfFriends] FROM TransitiveFriendship
GROUP BY id1 ) AS tbl  GROUP BY numberOfFriends) AS t ORDER BY mediana DESC

-- 3 самых влиятельных людей, влиятельные люди имеют наибольшее количество уникальных друзей друзей
