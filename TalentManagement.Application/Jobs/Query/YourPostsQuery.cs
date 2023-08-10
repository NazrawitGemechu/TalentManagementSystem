﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Application.Jobs.Query
{
    public class YourPostsQuery : IRequest<List<Job>>
    {
        public string RecruiterId { get; set; }
    }
}
