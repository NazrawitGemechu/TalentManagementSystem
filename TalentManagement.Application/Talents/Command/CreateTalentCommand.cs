using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Application.ViewModels;
using TalentManagement.Domain.Entities;


namespace TalentManagement.Application.Talents.Command
{
    public class CreateTalentCommand : IRequest<IActionResult>
    {
        public CreateTalentViewModel Model { get; set; }
       
    }
}
