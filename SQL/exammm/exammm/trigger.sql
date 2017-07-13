﻿ALTER TRIGGER [HotelDeletion]
	ON [dbo].[Hotels]
	INSTEAD OF DELETE
	AS
		BEGIN
		declare @idc INT;
		declare @delId INT;
		declare @newHotel INT;
		SET @idc = (SELECT idCountry FROM deleted)
		SET @delId = (SELECT Id FROM deleted)
		SET @newHotel = (SELECT TOP (1) Hotels.Id FROM hotels WHERE Hotels.IdCountry = @idc AND Hotels.Id != @delId)

	  update tour set idHotel = @newHotel FROM Tour LEFT JOIN deleted ON idHotel = deleted.Id WHERE idHotel = deleted.Id
	  delete from hotels where hotels.id = @delId
	END