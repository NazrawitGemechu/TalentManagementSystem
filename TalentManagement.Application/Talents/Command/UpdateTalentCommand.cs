using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Application.ViewModels;

namespace TalentManagement.Application.Talents.Command
{
    public class UpdateTalentCommand :IRequest<IActionResult>
    {
        public CreateTalentViewModel Model { get; set; }
    }
}
