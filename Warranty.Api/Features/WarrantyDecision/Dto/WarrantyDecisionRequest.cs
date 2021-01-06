using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warranty.Api.Features.WarrantyDecision.Dto
{
    public class WarrantyDecisionRequest : IRequest<WarrantyDecisionResponse>
    {
        public Guid Id { get; set; }
        public bool IsInStock { get; set; }
    }
}
