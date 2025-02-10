using System.Diagnostics;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Mission6Movies.Models;

namespace Mission6Movies.Controllers;

public class HomeController : Controller
{
    
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
        return View("Confirmation", response);
    }
    
}