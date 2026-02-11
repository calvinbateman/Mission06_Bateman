using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Bateman.Models;

namespace Mission06_Bateman.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

}