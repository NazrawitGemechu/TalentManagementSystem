using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentManagement.Application.Companies.Query;
using TalentManagement.Application.Jobs.Query;
using TalentManagement.Application.Talents.Command;
using TalentManagement.Domain.Entities;
using TalentManagement.Persistance.Data;

namespace TalentManagement.UI.Controllers
{
   
    public class MainController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MainController(IMediator mediator, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Home(int Id)
        {
            //assigns the get jobs query to vat jobQuery
            var jobQuery = new GetJobsQuery();
            //assigns the get companiew query to vat companyQuery
            var companyQuery = new GetCompaniesQuery();
            //sends the job query stored in the variable throuth mediater to the query handler
            var jobResult = await _mediator.Send(jobQuery);
            //sends the company query stored in the variable throuth mediater to the query handler
            var companyResult = await _mediator.Send(companyQuery);
            //returns the job result that it recived form the handler
            //gets the user id of the current user
           
          
            return View(jobResult);
        }
        [Authorize(Roles="Admin")]
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public  IActionResult How()
        {

            return View();
        }
        public IActionResult AccessDenied()
        {

            return View();
        }

    }
}
