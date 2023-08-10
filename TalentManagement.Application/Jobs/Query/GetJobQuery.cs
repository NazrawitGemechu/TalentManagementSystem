using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentManagement.Application.ViewModels;
namespace TalentManagement.Application.Jobs.Query
{
    public class GetJobQuery : IRequest<PostAJobViewModel>
    {
        public int JobId { get; set; }
    }
}
