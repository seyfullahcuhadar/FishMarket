using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishMarket.UI.Controllers
{
    [Route("Fish")]
    [Authorize]
    public class FishController:Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOnPost()
        {
            return View();
        }
    }
}

