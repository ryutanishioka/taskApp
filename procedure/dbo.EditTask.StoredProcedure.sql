USE [TASK]
GO
/****** Object:  StoredProcedure [dbo].[EditTask]    Script Date: 2024/06/10 1:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditTask]
(
	@ID		int,
	@Description	nvarchar(500)
)
AS
BEGIN
	UPDATE Task
	SET [Description] = @Description
	WHERE ID = @ID
END
GO
