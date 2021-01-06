using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warranty.Api.Domain.Repositories;
using Warranty.Api.Features.DeleteWarranty.Dto;
using Warranty.Api.Features.Dto;
using Warranty.Api.Infrastructure.Database;

namespace Warranty.Api.Features.DeleteWarranty
{
    internal class DeleteWarrantyCommandHandler : IRequestHandler<DeleteWarrantyCommand, CommandResult>
    {
        private readonly IWarrantyRepository _warrantyRepository;
        private readonly WarrantyDbContext _warrantyDbContext;
        public DeleteWarrantyCommandHandler(IWarrantyRepository warrantyRepository, WarrantyDbContext warrantyDbContext)
        {
            _warrantyRepository = warrantyRepository;
            _warrantyDbContext = warrantyDbContext;
        }
        public async Task<CommandResult> Handle(DeleteWarrantyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var warranty = await _warrantyRepository.GetById(request.Id);
                if (warranty != null)
                {
                    warranty.ChangeStatusToCancel();
                    await _warrantyDbContext.SaveChangesAsync();
                    return new CommandResult
                    {
                        IsCompleted = true
                    };
                }
                throw new InvalidOperationException("Not found warranty with given guid");
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
