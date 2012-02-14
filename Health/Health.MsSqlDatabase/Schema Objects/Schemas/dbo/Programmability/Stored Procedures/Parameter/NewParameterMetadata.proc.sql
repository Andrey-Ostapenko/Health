﻿CREATE PROCEDURE [dbo].[NewParameterMetadata]
	@ParameterId int,
	@Key nvarchar(max),
	@Value varbinary(max),
	@ValueTypeId int
AS
	declare @status int = 1
	declare @statusMessage nvarchar(MAX) = dbo.GSM(0000001)
	
	begin try
		insert ParameterMetadata (ParameterId, [Key], Value, ValueTypeId) 
		values (@ParameterId, @Key, @Value, @ValueTypeId)
	end try

	begin catch
		set @status = 0
		set @statusMessage = dbo.GSM(0000000)
	end catch

	select @status as Status, @statusMessage as StatusMessage
RETURN 0