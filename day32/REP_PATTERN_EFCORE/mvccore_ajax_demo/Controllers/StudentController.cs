using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvccore_ajax_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace mvccore_ajax_demo.Controllers;

public class studentController : Controller
{
    private readonly StudentContext _context;
    public studentController(StudentContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public ActionResult createStudent(Student std)
    {
       _context.Students.Add(std);
        _context.SaveChanges();
        string message = "SUCCESS";
        return Json(new { Message = message, JsonRequestBehavior.AllowGet });
    }
    public ActionResult getStudent(string id)
    {
        List<Student> students = new List<Student>();
        students = _context.Students.ToList();
        return Json(students, JsonRequestBehavior.AllowGet);
    }

}