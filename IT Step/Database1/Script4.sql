select * from People;

select COUNT(*) as Kolichestvo,MoodId
	from People 
	group by MoodId;

select * from (
	select COUNT(*) a,MoodId
		from People 
		group by MoodId
	) tbl
	inner join Moods on tbl.MoodId = Moods.Id


--select count(Firstname), MAX(Id),Lastname,MoodId
-- from People 
--group by Lastname,MoodId
