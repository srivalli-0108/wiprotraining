SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Users'
ORDER BY ORDINAL_POSITION;
   



   -- Insert user
INSERT INTO dbo.Users (Name, Email, Password, [Role])
VALUES ('Harika', 'harika@example.com', 'haari123', 'Admin');
GO

-- Query users
SELECT * FROM dbo.Users WHERE [Role] = 'Admin';
GO

-- Insert a user
INSERT INTO Users (Name, Email, Password, [Role])
VALUES ('Harika', 'harika@example.com', 'haari123', 'Admin');

-- Get the ID of the inserted user
DECLARE @UserId INT = SCOPE_IDENTITY();

-- Insert a question from that user
INSERT INTO Questions (UserId, QuestionText, Status, CreatedAt)
VALUES (@UserId, 'What is SQL?', 'Pending', GETDATE());

-- Get the ID of the inserted question
DECLARE @QuestionId INT = SCOPE_IDENTITY();

-- Insert an answer by that user to that question
INSERT INTO Answers (QuestionId, UserId, AnswerText, Status, CreatedAt)
VALUES (@QuestionId, @UserId, 'SQL is a query language for databases.', 'Pending', GETDATE());
