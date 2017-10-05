
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[VerifyUser]
@userName nvarchar(255),
@password nvarchar(255)

AS
BEGIN
IF EXISTS (SELECT UserName FROM Users WHERE UserName =  @userName and Password = @password)
	RETURN 1
ELSE RETURN 0
END