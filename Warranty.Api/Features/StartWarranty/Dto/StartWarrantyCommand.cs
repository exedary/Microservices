using MediatR;
using System;
using Warranty.Api.Features.Dto;

namespace Warranty.Api.Features.StartWarranty.Dto
{
    public class StartWarrantyCommand : IRequest<CommandResult>
    {
        public Guid Id { get; set; }
    }
}
