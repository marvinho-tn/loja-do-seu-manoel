using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Domain.Services;

namespace Store.Api.Controllers;

[Route("produtos")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetAllProducts()
    {
        var result = productService.GetAllProducts();
        var resultViewModel = new ResultViewModel(result.Obj.ConvertToViewModelResult(), result.Errors);
            
        if (!result.IsValid())
        {
            return BadRequest(resultViewModel);
        }
            
        return Ok(resultViewModel);
    }
}