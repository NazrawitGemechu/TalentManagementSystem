﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentManagement.Application.Admin.Command
{
    public class RejectTalentCommand : IRequest<Unit>
    {
        public int TalentId { get; set; }
    }
}
