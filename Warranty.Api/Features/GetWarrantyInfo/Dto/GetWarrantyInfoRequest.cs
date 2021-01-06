using MediatR;
using System;

namespace Warranty.Api.Features.GetWarrantyInfo.Dto
{
    public class GetWarrantyInfoRequest : IRequest<GetWarrantyInfoResponse>
    {
        public Guid Id { get; set; }
    }
}
