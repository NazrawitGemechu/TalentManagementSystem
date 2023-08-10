﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Application.EducationLevels.Query
{
    public class GetAllEducationLevelsQuery : IRequest<List<EducationLevel>>
    {
    }
}
