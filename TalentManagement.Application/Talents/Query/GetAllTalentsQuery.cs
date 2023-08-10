using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Domain.Entities;

namespace TalentManagement.Application.Talents.Query
{
    public class GetAllTalentsQuery : IRequest<List<Talent>>
    {
    }
}
