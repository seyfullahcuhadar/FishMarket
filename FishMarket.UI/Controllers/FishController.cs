using System;
using FishMarket.Application.Fishes.CreateFish;
using FishMarket.Application.Fishes.GetFish;
using FishMarket.Application.Fishes.GetFishes;
using FishMarket.Application.Fishes.UpdateFish;
using FishMarket.UI.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FishMarket.UI.Controllers
{
    [Route("Fish")]
    [Authorize]
    public class FishController:Controller
    {
        private readonly IMediator mediator;

        public FishController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var fishes = await mediator.Send(new GetFishesQuery());
            return View(fishes);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateOnPost(CreateFishCommand createFishCommand)
        {
            if (!ModelState.IsValid)
                return View("Create", createFishCommand);
            createFishCommand.ImageBytes = await createFishCommand.ImageFormFile.GetBytesAsync();
            await mediator.Send(createFishCommand);
            return RedirectToAction("Index", "Fish");
        }

        [HttpGet("{fishId}")]
        public async Task<ActionResult> Update(Guid fishId)
        {
            var query = new GetFishQuery(fishId);
            var fish = await mediator.Send(query);
            return View("Update", fish);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(FishMarket.Application.Fishes.GetFish.FishDTO fishDTO)
        {
            if (!ModelState.IsValid)
                return View("Update", fishDTO);

            var updateFishCommand = new UpdateFishCommand(fishDTO.Id, fishDTO.Name, fishDTO.Price);
            await mediator.Send(updateFishCommand);
            return RedirectToAction("Index", "Fish");
        }


    }
}

