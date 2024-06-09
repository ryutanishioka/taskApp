USE [TASK]
GO
/****** Object:  StoredProcedure [dbo].[AddTask]    Script Date: 2024/06/10 1:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTask]
(
	@Name		nvarchar(255),
	@Description  nvarchar(500),
	@Priority	int
)
AS
BEGIN
	INSERT INTO Task(Name, Description, Priority, CreateDate)
	VALUES (@NAME, @Description, @Priority, GETDATE())
END
GO
