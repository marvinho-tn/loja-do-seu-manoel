using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Domain.Services;

namespace Store.Api.Controllers
{
    /// <summary>
    /// Controller de pedidos da API.
    /// </summary>
    /// <param name="orderService">Serviço que faz a gestão dos pedidos.</param>
    [Route("pedidos")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        /// <summary>
        /// Endpoint de processamento dos pedidos.
        /// </summary>
        /// <param name="ordersModel">Modelo que contem a listagem de pedidos.</param>
        /// <returns>Resultado do processamento.</returns>
        [HttpPost]
        [Authorize]
        public IActionResult PostOrders([FromBody] CreateOrdersModel ordersModel)
        {
            var orders = ordersModel.ConvertToOrder();
            var result = orderService.ProcessOrders(orders);
            var resultViewModel = new ResultViewModel(result.Obj.ConvertToViewModelResult(), result.Errors);

            if (!result.IsValid())
            {
                return UnprocessableEntity(resultViewModel);
            }
            
            return Created("pedidos", resultViewModel);
        }

        /// <summary>
        /// Endpoint de listagem de pedidos.
        /// </summary>
        /// <returns>Listagem de pedidos.</returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetOrders()
        {
            var result = orderService.GetAllOrders();
            var resultViewModel = new ResultViewModel(result.Obj.ConvertToViewModelResult(), result.Errors);
            
            if (!result.IsValid())
            {
                return BadRequest(resultViewModel);
            }
            
            return Ok(resultViewModel);
        }
    }
}
