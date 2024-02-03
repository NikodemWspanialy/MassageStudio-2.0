using MassageStudio.Application.ApplicationUser.Commands.AddRoleToUser;
using MassageStudio.Application.ApplicationUser.Commands.DeleteUser;
using MassageStudio.Application.ApplicationUser.Commands.DeleteUserRole;
using MassageStudio.Application.ApplicationUser.Queries.GetAllUsers;
using MassageStudio.Application.ApplicationUser.Queries.GetApplicationUserDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MassageStudio.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserManagerController : Controller
    {
        private readonly IMediator mediator;

        public UserManagerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {

            var users = await mediator.Send(new GetAllUsersQuery());
            return View(users);
        }
        [Route("MassageStudio/Details/{name}_{lastName}")]
        public async Task<IActionResult> DetailsAsync(string id, string name, string lastName)
        {
            var user = await mediator.Send(new GetApplicationUserDetailsByIdQuery(id));
            return View(user);
        }
        public async Task<IActionResult> UpgradeAdminAsync(string id)
        {
            await mediator.Send(new AddRoleToUserCommand(id, "Admin"));

            string refferer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(refferer))
                return Redirect(refferer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpgradeMasseurAsync(string id)
        {
            await mediator.Send(new AddRoleToUserCommand(id, "Masseur"));

            string refferer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(refferer))
                return Redirect(refferer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAdminAsync(string id)
        {
            await mediator.Send(new DeleteUserRoleCommand(id, "Admin"));
            string refferer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(refferer))
                return Redirect(refferer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteMasseurAsync(string id)
        {
            await mediator.Send(new DeleteUserRoleCommand(id, "Masseur"));

            string refferer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(refferer))
                return Redirect(refferer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            await mediator.Send(new DeleteUserCommand(id));
            return RedirectToAction("Index");
        }
    }
}
