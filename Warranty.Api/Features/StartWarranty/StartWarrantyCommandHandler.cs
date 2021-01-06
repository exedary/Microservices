using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warranty.Api.Domain.Repositories;
using Warranty.Api.Features.Dto;
using Warranty.Api.Features.StartWarranty.Dto;

namespace Warranty.Api.Features.StartWarranty
{
    internal class StartWarrantyCommandHandler : IRequestHandler<StartWarrantyCommand, CommandResult>
    {
        private readonly IWarrantyRepository _warrantyRepository;
        public StartWarrantyCommandHandler(IWarrantyRepository warrantyRepository)
        {
            _warrantyRepository = warrantyRepository;
        }

        public async Task<CommandResult> Handle(StartWarrantyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var warranty = Domain.Warranty.Create(request.Id, TimeSpan.FromDays(365));
                await _warrantyRepository.Add(warranty);
                return new CommandResult
                {
                    IsCompleted = true
                };
            }

            catch (Exception ex)
            {
                return new CommandResult
                {
                    IsCompleted = false,
                    Reason = ex.Message
                };
            }
        }
    }
}
