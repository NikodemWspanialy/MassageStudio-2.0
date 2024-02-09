using MassageStudio.Application.ApplicationUser;
using MassageStudio.Application.Massages.Queries.GetMassageDetails;
using MassageStudio.Application.UserActions.Commands.ReserveTerm;
using MassageStudio.Application.UserActions.Commands.UnreserveTerm;
using MassageStudio.Application.UserActions.Queries.GetMassages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MassageStudio.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserContext userContext;

        public UserController(IMediator mediator, IUserContext userContext)
        {
            this.mediator = mediator;
            this.userContext = userContext;
        }
        [HttpGet]
        public async Task<IActionResult> AllTermsAsync()
        {
            var massages = await mediator.Send(new GetMassagesQuery(m => m.Free == true));
            return View(massages);
        }
        [HttpGet]
        public async Task<IActionResult> UserTermsAsync()
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null)
            {
                var massages = await mediator.Send(new GetMassagesQuery(m => m.ClientId == currentUser.Id));
                return View(massages);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsAsync(string id)
        {
            var massage = await mediator.Send(new GetMassageDetailsQuery(id));
            return View(massage);  
        }
        [HttpGet]
        public IActionResult Reserve(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ReserveAsync(string id)
        {
            var result = await mediator.Send(new ReserveTermCommand(id));
            if(result == IdentityResult.Success)
            {
                return RedirectToAction("UserTerms", "User");
            }
            else
            {
                //log massage 
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult UnreserveAsync(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Unreserve(string id)
        {
            var result = await mediator.Send(new UnreserveTermCommand(id));
            if (result == IdentityResult.Success)
            {
                return RedirectToAction("UserTerms", "User");
            }
            else
            {
                //log massage 
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
