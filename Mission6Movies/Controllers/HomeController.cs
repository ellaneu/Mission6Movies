using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Mission6Movies.Models;

namespace Mission6Movies.Controllers;

public class HomeController : Controller
{
    
    private MovieApplicationContext _context;

    public HomeController(MovieApplicationContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }
    

    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }

    [HttpPost]

    public IActionResult MovieForm(MovieApplication response)
    {
        
        _context.MovieApplications.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
    
}