using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Warehouse.Api.Features.CancelOrder.Dto;
using Warehouse.Api.Features.CreateOrder.Dto;
using Warehouse.Api.Features.GetOrderInfo;

namespace Warehouse.Api.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Метод возвращает информацию о вещах на складе
        /// </summary>
        /// <param name="orderItemUid"></param>
        [HttpGet("{orderItemUid}")]
        public async Task<IActionResult> GetOrderItemInfo(Guid orderItemUid)
        {
            var response = await _mediator.Send(new GetOrderInfoRequest
            {
                Id = orderItemUid
            });
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Метод запрашивает вещи со склада по заказу
        /// </summary>
        [HttpPost("")]
        public async Task<IActionResult> RequestItem([FromBody] CreateOrderCommand request)
        {
            var response = await _mediator.Send(request);
            if (response.IsCompleted)
            {
                return Ok(response);
            }
            return StatusCode(500, response.Reason);
        }

        /// <summary>
        /// Метод запрашивает решение гарантии
        /// </summary>
        /// <param name="orderItemUid"></param>
        [HttpPost("{orderItemUid}/warranty")]
        public async Task<IActionResult> RequestWarranty(Guid orderItemUid)
        {
            var response = await _mediator.Send(new WarrantyRequest.WarrantyRequest(orderItemUid));
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        /// <summary>
        /// Метод для отмены заказа и возврата товаров на склад
        /// </summary>
        /// <param name="orderItemUid"></param>
        [HttpDelete("{orderItemUid}")]
        public async Task<IActionResult> ReturnItemToWarehouse(Guid orderItemUid)
        {
            var response = await _mediator.Send(new CancelOrderCommand(orderItemUid));
            if (response.IsCompleted)
            {
                return Ok(response);
            }
            return StatusCode(500, response.Reason);
        }
    }
}
