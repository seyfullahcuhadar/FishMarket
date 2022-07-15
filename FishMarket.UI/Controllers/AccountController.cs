using FishMarket.Application.Accounts.Login;
using FishMarket.Application.Accounts.Register;
using FishMarket.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FishMarket.UI.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult LoginOnPost(LoginQuery loginQuery)
        {
            return View(loginQuery);
        }

        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]

        public async Task<ActionResult> RegisterOnPostAsync(RegisterCommand model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register",model);
            }
            await mediator.Send(model);
            return RedirectToAction("Index", "Home");
        }

    }
}