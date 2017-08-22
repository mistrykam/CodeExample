BEGIN TRY
	PRINT 'before';
	--RAISERROR ('raiserror - opps i did it again', 15, 0);
	THROW 50000, 'throw opps i did it again', 0;
	PRINT 'after';
END TRY
BEGIN CATCH
	PRINT 'Caught it'
END CATCH
