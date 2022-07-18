using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FishMarket.Application.Emails;

namespace FishMarket.UI.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }
}

