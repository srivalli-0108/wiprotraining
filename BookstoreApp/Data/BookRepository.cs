using System.Data;
using Microsoft.Data.SqlClient;
using BookstoreApp.Models;
namespace BookstoreApp.Data
{

    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // ✅ 1. Get All Books (SqlDataReader)
        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("SELECT * FROM Books", conn);
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                books.Add(new Book
                {
                    Id = (int)reader["Id"],
                    Title = reader["Title"].ToString(),
                    Author = reader["Author"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"])
                });
            }
            return books;
        }

        // ✅ 2. Add Book (Parameterized Query)
        public void AddBook(Book book)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("INSERT INTO Books (Title, Author, Price) VALUES (@Title, @Author, @Price)", conn);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ✅ 3. Update Book
        public void UpdateBook(Book book)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("UPDATE Books SET Title = @Title, Author = @Author, Price = @Price WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Title", book.Title);
            cmd.Parameters.AddWithValue("@Author", book.Author);
            cmd.Parameters.AddWithValue("@Price", book.Price);
            cmd.Parameters.AddWithValue("@Id", book.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ✅ 4. Delete Book
        public void DeleteBook(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("DELETE FROM Books WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            conn.Open();
            cmd.ExecuteNonQuery();
        }

        // ✅ 5. Using DataSet and SqlDataAdapter
        public DataSet GetBooksUsingDataSet()
        {
            using var conn = new SqlConnection(_connectionString);
            var da = new SqlDataAdapter("SELECT * FROM Books", conn);
            var ds = new DataSet();
            da.Fill(ds, "Books");
            return ds;
        }
    }
}
