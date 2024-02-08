using AutoMapper;
using MassageStudio.Application.ApplicationUser;
using MassageStudio.Application.Massages.Commands.CreateMassageEmpty;
using MassageStudio.Application.Massages.Commands.DeleteMasage;
using MassageStudio.Application.Massages.Commands.EditMassage;
using MassageStudio.Application.Massages.Dtos;
using MassageStudio.Application.Massages.Queries.GetAllMassages;
using MassageStudio.Application.Massages.Queries.GetFutureMassages;
using MassageStudio.Application.Massages.Queries.GetMassageDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MassageStudio.MVC.Controllers
{
    [Authorize(Roles = "Masseur")]
    public class MasseurController : Controller
    {
        private readonly IMediator mediator;
        private readonly IUserContext userContext;
        private readonly IMapper mapper;

        public MasseurController(IMediator mediator, IUserContext userContext, IMapper mapper)
        {
            this.mediator = mediator;
            this.userContext = userContext;
            this.mapper = mapper;
        }
        // GET: MasseurController - list of massages
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var massageListedDto = await mediator.Send(new GetFutureMassagesQuery());
                return View(massageListedDto);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: MasseurController - list of massages
        [HttpGet]
        public async Task<IActionResult> History()
        {
            try
            {
                var massageListedDto = await mediator.Send(new GetPreviousMassagesQuery());
                return View(massageListedDto);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        // GET: MasseurController/Details/5 - szczegoly
        [HttpGet]
        public async Task<IActionResult> DetailsAsync(string id)
        {
            try
            {
                var MassageDetails = await mediator.Send(new GetMassageDetailsQuery(id));
                if (MassageDetails != null)
                {
                    return View(MassageDetails);
                }
            }
            catch
            {
                //logger 
            }
            return RedirectToAction("Index");
        }

        // GET: MasseurController/Create - view
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            var user = await userContext.GetCurrentUserAsync();
            if (user != null)
            {

                var model = new CreateMassagEmptyDto()
                {
                    MasseurName = user.Name,
                    MasseurLastName = user.LastName,
                    MasseurId = user.Id
                };
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: MasseurController/Create - action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CreateMassagEmptyDto createMassagEmptyDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = mapper.Map<CreateMassageEmptyCommand>(createMassagEmptyDto);
                    var resultId = await mediator.Send(command);
                    return RedirectToAction("Details", "Masseur", resultId);
                }
                catch
                {
                    //logger / informacja zwrotna
                }
            }
            return View(createMassagEmptyDto);
        }

        // GET: MasseurController/Edit/5 - view
        [HttpGet]
        public async Task<IActionResult> EditAsync(string id)
        {
            try
            {
                var massageDto = await mediator.Send(new GetMassageDetailsQuery(id));
                var editmassageDto = mapper.Map<EditMassageDto>(massageDto);
                return View(editmassageDto);
            }
            catch
            {
                //logger
            }
            return RedirectToAction("Details", "Masseur", id);
        }

        // POST: MasseurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMassageDto massageDto)
        {
            try
            {
                var massageCommand = mapper.Map<EditMassageCommand>(massageDto);
                await mediator.Send(massageCommand);
            }
            catch
            {
                //Logger
            }
            return RedirectToAction("Details", "Masseur", massageDto.Id);
        }

        // GET: MasseurController/Delete/5
        [HttpGet]
        public IActionResult Delete(string id)
        {
            ViewData["MassageId"] = id;
            return View();
        }

        // POST: MasseurController/Delete/5
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubmited(string id)
        {
            try
            {
                await mediator.Send(new DeleteMassageCommand(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Details", "Masseur", id);
            }

        }
    }
}
