using Microsoft.AspNetCore.Mvc;
using BookstoreApp.Data;
using BookstoreApp.Models;

public class BookController : Controller {
    private readonly BookRepository _repo;

    public BookController(IConfiguration config) {
        _repo = new BookRepository(config);
    }

    public IActionResult Index() {
        var books = _repo.GetAllBooks();
        return View(books);
    }

    public IActionResult Add() => View();

    [HttpPost]
    public IActionResult Add(Book book) {
        _repo.AddBook(book);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id) {
        var book = _repo.GetAllBooks().FirstOrDefault(b => b.Id == id);
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book) {
        _repo.UpdateBook(book);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id) {
        _repo.DeleteBook(id);
        return RedirectToAction("Index");
    }
}
