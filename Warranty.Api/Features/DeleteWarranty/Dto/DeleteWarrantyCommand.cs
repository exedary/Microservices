using MediatR;
using System;
using Warranty.Api.Features.Dto;

namespace Warranty.Api.Features.DeleteWarranty.Dto
{
    internal class DeleteWarrantyCommand : IRequest<CommandResult>
    {
        public Guid Id { get; set; }
    }
}
