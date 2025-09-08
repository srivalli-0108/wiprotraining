using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Data;


public class BookController : Controller
{
    private readonly ApplicationDbContext _context;
    public BookController(ApplicationDbContext context) => _context = context;

    public async Task<IActionResult> Index() => View(await _context.Books.ToListAsync());

    public async Task<IActionResult> Details(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();
        return View(book);
    }
    
}
