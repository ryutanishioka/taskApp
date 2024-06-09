USE [TASK]
GO
/****** Object:  StoredProcedure [dbo].[GetTask]    Script Date: 2024/06/10 1:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTask]

AS
BEGIN
	SELECT 
		ID,
		[Name],
		[Description],
		[Priority],
		CreateDate
	FROM Task
END
GO
