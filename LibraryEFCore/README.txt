USE LibraryDb;
GO

-- Drop the tables if they exist
IF OBJECT_ID('dbo.BookGenres', 'U') IS NOT NULL DROP TABLE BookGenres;
IF OBJECT_ID('dbo.Books', 'U') IS NOT NULL DROP TABLE Books;
IF OBJECT_ID('dbo.Genres', 'U') IS NOT NULL DROP TABLE Genres;
IF OBJECT_ID('dbo.Authors', 'U') IS NOT NULL DROP TABLE Authors;
GO

-- Now recreate the tables
CREATE TABLE Authors (
    AuthorID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Bio NVARCHAR(MAX)
);

CREATE TABLE Genres (
    GenreID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Books (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    AuthorID INT NOT NULL,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

CREATE TABLE BookGenres (
    BookID INT NOT NULL,
    GenreID INT NOT NULL,
    PRIMARY KEY (BookID, GenreID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID),
    FOREIGN KEY (GenreID) REFERENCES Genres(GenreID)
);
