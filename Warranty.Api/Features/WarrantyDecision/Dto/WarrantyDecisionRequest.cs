using MediatR;
using System;

namespace Warranty.Api.Features.WarrantyDecision.Dto
{
    public class WarrantyDecisionRequest : IRequest<WarrantyDecisionResponse>
    {
        public Guid Id { get; set; }
        public bool IsInStock { get; set; }
    }
}
