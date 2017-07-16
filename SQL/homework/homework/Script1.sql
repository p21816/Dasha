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
select TOP (3) id1, COUNT(id1) as numberOfUniqueFriendsOfFriends from (SELECT s.id1, t.id2  FROM TransitiveFriendship s LEFT JOIN TransitiveFriendship t
ON t.id1 = s.id2 
WHERE s.id1 != t.id2
GROUP BY s.id1 , t.id2) as ttt GROUP BY id1 ORDER BY numberOfUniqueFriendsOfFriends DESC

---------- ЗАДАНИЕ 4 ----------
--Добавить в таблицу People поле пол CHAR(1) с ограничением на значения M (Male) и F (Female)
SELECT * FROM People
ALTER TABLE People ADD Sex CHAR(1) CHECK (Sex in('M' , 'F'))
UPDATE People SET Sex = 'M' WHERE PersonalNumber in(12, 13, 14, 15, 16)
UPDATE People SET Sex = 'F' WHERE PersonalNumber in(11, 17, 18)

--В результате установления демократического строя в провинции Кират целях совершенствования порядка учёта граждан в законодательство были внесены поправки,
--отменяющие бинарный характер учёта пола, и вводящий взамен характеристики
--генетического пола, гонадного пола, внутреннего и внешнего генитального пола, гендрной и сексуальной идентичности. 
--Не уничтожая данные таблицы people привести её в соответствие с законодательством провинции Кират
ALTER TABLE People ADD GeneticSex CHAR(2) CHECK (GeneticSex in('XY' , 'XX'))
UPDATE People SET GeneticSex = 'XY' WHERE PersonalNumber in(12, 13, 14, 15, 16)
UPDATE People SET GeneticSex = 'XX' WHERE PersonalNumber in(11, 17, 18)


ALTER TABLE People ADD GonadalSex NVARCHAR(30)
ALTER TABLE People ADD InternalGenitalSex NVARCHAR(30)
ALTER TABLE People ADD ExternalGenitalSex NVARCHAR(30)
ALTER TABLE People ADD GenderIdentity NVARCHAR(30)
ALTER TABLE People ADD SexualIdentity NVARCHAR(30)

