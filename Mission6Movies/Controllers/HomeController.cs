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
        
        return View();
    }

    // Adds the contents of the form to the MovieApplications database and saves it
    // Returns the confirmation view so the user knows the form was recieved
    [HttpPost]
    public IActionResult MovieForm(MovieApplication response)
    {
        
        _context.Movies.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
    
    
    public IActionResult MovieList()
    {
        
        // linq
        var applications = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        
        return View(applications);
    }
    
}