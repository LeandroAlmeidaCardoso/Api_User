CREATE PROCEDURE [dbo].[spUser_Delete]
@Id int
AS
BEGIN
	delete 
	FROM [dbo].[MinimalApi]..[User]
	Where Id = @Id;
END