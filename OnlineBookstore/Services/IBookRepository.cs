using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
}

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();
    public async Task<Book> GetByIdAsync(int id) => await _context.Books.FindAsync(id);
}
