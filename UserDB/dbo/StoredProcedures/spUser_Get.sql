CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int 
AS
	SELECT * FROM [dbo].[User](NOLOCK)
	WHERE Id = @Id
RETURN 0
