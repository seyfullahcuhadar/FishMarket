using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FishMarket.Application.Emails;

namespace FishMarket.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEmailSender emailSender;

    public HomeController(ILogger<HomeController> logger,IEmailSender emailSender)
    {
        _logger = logger;
        this.emailSender = emailSender;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


}

