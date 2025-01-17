﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Application.Admin.Query;
using TalentManagement.Domain.Entities;
using TalentManagement.Persistance.Data;

namespace TalentManagement.Application.Admin.QueryHandler
{
    public class RejectedPostsQueryHandler : IRequestHandler<RejectedPostsQuery, List<Job>>
    {
        private readonly ApplicationDbContext _context;

        public RejectedPostsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Job>> Handle(RejectedPostsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await _context.Jobs.Where(x => x.IsAccepted == false)
                .Include(x => x.Recruter)
                .ToListAsync();

            return jobs;
        }
    }
}
