using FishMarket.Application.Accounts.ConfirmEmail;
using FishMarket.Application.Accounts.Login;
using FishMarket.Application.Accounts.Logout;
using FishMarket.Application.Accounts.Register;
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
        public async Task<ActionResult> LoginOnPost(LoginCommand model)
        {
            var result = await mediator.Send(model);
            if (result)
                return RedirectToAction("Index", "Home");
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View("Login",model);

            }

        }

        [HttpGet]
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]

        public async Task<ActionResult> RegisterOnPostAsync(RegisterCommand model)
        {
            var requestUrl = $"{Request.Scheme}://{Request.Host}";
            model.CurrentUrl = requestUrl;
            if (!ModelState.IsValid)
            {
                return View("Register",model);
            }
            await mediator.Send(model);
            return RedirectToAction("ConfirmationMailSent", "Account");
        }

        [HttpGet("ConfirmEmailAddress")]
        public async Task<ActionResult> ConfirmEmailAddressAsync([FromQuery] string confirmationToken,[FromQuery] string emailAddress)
        {
            var confirmCommand = new ConfirmEmailCommand { EmailAddress = emailAddress, Token = confirmationToken };
            await mediator.Send(confirmCommand);
            return RedirectToAction("ConfirmSuccessful", "Account", emailAddress);
        }

        [HttpGet("ConfirmationSuccessful")]
        public ActionResult ConfirmSuccessful(string emailAddress)
        {
            return View(emailAddress);
        }

        public ActionResult ConfirmationMailSent()
        {
            return View();
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogoutAsync()
        {
            await mediator.Send(new LogoutCommand());
            return RedirectToAction("Index", "Home");
        }
    }
}