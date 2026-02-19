using Microsoft.AspNetCore.Mvc;
using Mission06_Bateman.Data;
using Mission06_Bateman.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Mission06_Bateman.Controllers;

public class MoviesController : Controller
{
    private readonly MovieCollectionContext _context;

    public MoviesController(MovieCollectionContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var movies = _context.Movies
            .OrderBy(m => m.Title)
            .ToList();
        
        return View(movies);
    }

// Get: /Movies/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }
        
        return View("Create", movie);
    }

    [HttpPost]
    
    public IActionResult Edit(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(response);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        return View(response);
    }
    
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        TempData["Message"] = "Movie deleted successfully!";
        return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        return View("Create", response);
    }

}