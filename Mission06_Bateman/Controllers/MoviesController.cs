using Microsoft.AspNetCore.Mvc;
using Mission06_Bateman.Data;
using Mission06_Bateman.Models;


namespace Mission06_Bateman.Controllers;

public class MoviesController : Controller
{
    private readonly MovieCollectionContext _context;

    public MoviesController(MovieCollectionContext context)
    {
        _context = context;
    }

    // Get: /Movies/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Post: /Movies/Create
    [HttpPost]
    public IActionResult Create(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            TempData["Message"] = "Movie added successfully!";
            return RedirectToAction("Create");
        }
        return View(response);
    }

}