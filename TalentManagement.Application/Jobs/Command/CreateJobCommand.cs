﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Application.ViewModels;

namespace TalentManagement.Application.Jobs.Command
{
    public class CreateJobCommand : IRequest<IActionResult>
    {
        public PostAJobViewModel Model { get; set; }
    }
}
