using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Warranty.Api.Features.DeleteWarranty.Dto;
using Warranty.Api.Features.GetWarrantyInfo.Dto;
using Warranty.Api.Features.StartWarranty.Dto;
using Warranty.Api.Features.WarrantyDecision.Dto;

namespace Warranty.Api.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarrantyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WarrantyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{itemUid}")]
        public async Task<IActionResult> GetWarrantyStatus(Guid itemUid)
        {
            var response = await _mediator.Send(new GetWarrantyInfoRequest { Id = itemUid });
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost("{itemUid}/warranty")]
        public async Task<IActionResult> DecideWarrancy(Guid itemUid, [FromBody]WarrantyDecisionRequestDto requestDto)
        {
            var response = await _mediator.Send(new WarrantyDecisionRequest { Id = itemUid, IsInStock = requestDto.IsInStock });
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost("{itemUid}")]
        public async Task<IActionResult> StartWarranty(Guid itemUid)
        {
            var response = await _mediator.Send(new StartWarrantyCommand { Id = itemUid });
            if (response.IsCompleted)
            {
                return Ok(response);
            }
            return StatusCode(500, response.Reason);
        }

        [HttpDelete("{itemUid}")]
        public async Task<IActionResult> CloseWarrancy(Guid itemUid)
        {
            var response = await _mediator.Send(new DeleteWarrantyCommand { Id = itemUid });
            if (response.IsCompleted)
            {
                return Ok(response);
            }
            return StatusCode(500, response.Reason);
        }
    }
}
