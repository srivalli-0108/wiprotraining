using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryEFCore.Models.DbFirst;

namespace LibraryDbFirstApp.Controllers;

public class BooksController : Controller
{
    private readonly LibraryDbContext _context;

    public BooksController(LibraryDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var books = _context.Books
            .Include(b => b.Author)
            .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
            .ToList();

        return View(books);
    }
}
