using System.Diagnostics;
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

    public IActionResult MovieForm()
    {
        return View();
    }
    
}