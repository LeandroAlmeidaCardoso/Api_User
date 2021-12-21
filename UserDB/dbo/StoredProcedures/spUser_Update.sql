CREATE PROCEDURE [spUser_Update]
@Id int,
@LastName nvarchar(50)
AS
BEGIN
		Update [dbo].[USER] 
		SET LastName = @LastName
		WHERE Id = @Id;
END