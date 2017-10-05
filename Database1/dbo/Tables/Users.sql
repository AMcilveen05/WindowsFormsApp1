CREATE TABLE [dbo].[Users] (
    [UserName]  VARCHAR (255) NOT NULL,
    [Password]  VARCHAR (255) NOT NULL,
    [FirstName] VARCHAR (255) NOT NULL,
    [LastName]  VARCHAR (255) NOT NULL,
    [UserID]    INT           IDENTITY (1, 1) NOT NULL
);

