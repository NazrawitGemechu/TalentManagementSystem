﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Application.Talents.Query;
using TalentManagement.Domain.Entities;
using TalentManagement.Persistance.Data;

namespace TalentManagement.Application.Talents.QueryHandler
{
    public class GetAllTalentsHandler : IRequestHandler<GetAllTalentsQuery, List<Talent>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllTalentsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Talent>> Handle(GetAllTalentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Talents.ToListAsync();
        }
    }
}
