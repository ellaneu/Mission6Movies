using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6Movies.Models;

namespace Mission6Movies.Controllers;

public class HomeController : Controller
{
    
    // Will store a reference to the injected MovieApplicationContext instance
    private MovieApplicationContext _context;

    // Constructor for HomeController that takes an instance MovieApplicationContext as a parameter
    // Constructor assigns injected context to the private _context
    public HomeController(MovieApplicationContext context)
    {
        _context = context;
    }
    
    // When called returns the Index or home screen view
    public IActionResult Index()
    {
        return View();
    }

    // When called returns the Get To Know Joel view
    public IActionResult GetToKnow()
    {
        return View();
    }
    
    //  When called returns the Movie Form view
    [HttpGet]
    public IActionResult MovieForm()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("MovieForm", new MovieApplication());
    }

    // Adds the contents of the form to the MovieApplications database and saves it
    // Returns the confirmation view so the user knows the form was recieved
    [HttpPost]
    public IActionResult MovieForm(MovieApplication response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
        
            return View("Confirmation", response);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            return View(response);
        }
    }
    
    // Loads the information from the database using linq when the MovieList view is called
    public IActionResult MovieList()
    {
        // linq
        var applications = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        
        return View(applications);
    }
    
    // When the edit button is clicked the specific movie id is passed as a parameter and takes the user to the 
    // Movie Form view with the specified information filled in
    [HttpGet]
    public IActionResult Edit(int id)
    {
        MovieApplication recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("MovieForm", recordToEdit);
    }

    // After editing the information it is updated in the database and the user is redirected to the list of movies
    [HttpPost]
    public IActionResult Edit(MovieApplication app)
    {
        _context.Update(app);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
    // Gets the specified movie based on its id and takes the user to the confirmation delete page
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordtoDelete = _context.Movies
            .Single(x => x.MovieId == id);
       
        return View(recordtoDelete);
    }

    // If the user pushes the delete button then this action is triggered and removes the movie from the database
    // After removing the movie the user is redirected back to the list of movies
    [HttpPost]
    public IActionResult Delete(MovieApplication app)
    {
        _context.Movies.Remove(app);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
    
    
    
}