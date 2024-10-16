using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> PostOrdersAsync([FromBody] CreateOrdersModel ordersModel)
        {
            var orders = ordersModel.ConvertToOrder();
            var result = await orderService.ProccessOrdersAsync(orders);

            if (!result.IsValid())
            {
                return UnprocessableEntity(result.Validations);
            }
            
            return Created("pedidos", result.ToViewModelResult().Obj);
        }
    }
}
