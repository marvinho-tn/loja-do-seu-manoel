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
        public async Task<IActionResult> PostOrdersAsync([FromBody] List<CreateOrderModel> ordersModel)
        {
            TryValidateModel(ordersModel);

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var orders = ordersModel.ConvertToOrder();
            var result = await orderService.ProccessOrdersAsync(orders);
            
            return Created("pedidos", result);
        }
    }
}
