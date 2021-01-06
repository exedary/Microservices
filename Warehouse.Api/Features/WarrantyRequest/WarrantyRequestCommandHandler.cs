using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Api.Features.Dto;

namespace Warehouse.Api.Features.WarrantyRequest
{
    public class WarrantyRequestCommandHandler : IRequestHandler<WarrantyRequestCommand, CommandResult>
    {
        public Task<CommandResult> Handle(WarrantyRequestCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
