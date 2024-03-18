using AutoMapper;
using MassageStudio.Application.ApplicationUser.Queries.UserIsInRoles;
using MassageStudio.Application.Types.Commands.AddType;
using MassageStudio.Application.Types.Commands.DeleteType;
using MassageStudio.Application.Types.Commands.EditType;
using MassageStudio.Application.Types.Queries.GetAllTypes;
using MassageStudio.Application.Types.Queries.GetTypeByName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MassageStudio.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TypeController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TypeController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //nie dizała - do rozwiazania problem
            var isEditable = await mediator.Send(new UserIsInRolesQuery("Admin"));
            ViewData["isEditableTypes"] = (isEditable == true ? "true" : "false");

            var allTypes = await mediator.Send(new GetAllTypesQuery());
            return View(allTypes);
        }

        [HttpGet]
        public IActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddType(AddTypeCommand addTypeCommand)
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(addTypeCommand);
                return RedirectToAction("Index");
            }
            return View(addTypeCommand);
        }

        [HttpGet]
        [Route("MassageStudio/{name}/Edit")]
        public async Task<IActionResult> Edit(string name)
        {
            var massageTypeDto = await mediator.Send(new GetTypeByNameQuery(name));
            var newModel = mapper.Map<EditTypeCommand>(massageTypeDto);
            return View(newModel);
            //stworzyc widok do edycji
        }

        [Route("MassageStudio/{name}/Edit")]
        public async Task<IActionResult> Edit(string name, EditTypeCommand editType)
        {
            await mediator.Send(editType);
            return RedirectToAction("Index", "Type");
        }
        public async Task<IActionResult> Delete(string name)
        {
            if (await mediator.Send(new UserIsInRolesQuery("Admin")))
            {
                await mediator.Send(new DeleteTypeCommand(name));
            }
            return RedirectToAction("Index");
        }
    }
}
