﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentManagement.Application.Jobs.Command
{
    public class DeleteJobCommand : IRequest<bool>
    {
        public int JobId { get; set; }
    }
}
