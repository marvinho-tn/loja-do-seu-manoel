using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Domain.Services;

namespace Store.Api.Controllers
{
    [Route("pedidos")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostOrdersAsync([FromBody] CreateOrdersModel ordersModel)
        {
            TryValidateModel(ordersModel);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orders = ordersModel.ConvertToOrder();
            var result = await orderService.ProccessOrdersAsync(orders);

            if (!result.IsValid())
            {
                return UnprocessableEntity(result);
            }
            
            return Created("pedidos", result.ToViewModelResult());
        }
    }
}
