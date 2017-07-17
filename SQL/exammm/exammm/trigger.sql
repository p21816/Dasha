ALTER TRIGGER [HotelDeletion]
	ON [dbo].[Hotels]
	INSTEAD OF DELETE
	AS
		BEGIN
		--declare @idc INT;
		--declare @delId INT;
		--declare @newHotel INT;
		--SET @idc = (SELECT idCountry FROM deleted)
		--SET @delId = (SELECT Id FROM deleted)
		--SET @newHotel = (SELECT TOP (1) Hotels.Id FROM hotels WHERE Hotels.IdCountry = @idc AND Hotels.Id != @delId)

	 -- update tour set idHotel = @newHotel FROM Tour LEFT JOIN deleted ON idHotel = deleted.Id WHERE idHotel = deleted.Id
	  --delete from hotels where hotels.id = @delId
	  select * from deleted join tour ON idHotel = deleted.Id 
	  select * from hotels left join deleted ON hotels.Id = deleted.Id WHERE deleted.Id IS NULL ;

	  WITH tmp AS(
	  	  select tour.ID, tour.IdHotel , MAX(Hotels.Id) as nId from deleted d1 join tour ON idHotel = d1.Id inner join
	   hotels ON tour.idCountry = hotels.idCountry left join deleted d2 ON hotels.Id = d2.Id WHERE d2.Id IS NULL group by tour.Id , tour.IdHotel) 
	   update tour set IdHotel = tmp.nId from tour join tmp ON tour.Id = tmp.Id
	  --update tour set idHotel = 7 
	END