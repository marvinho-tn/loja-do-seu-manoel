using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Domain.Services;

namespace Store.Api.Controllers;

[Route("caixas")]
[ApiController]
public class BoxesController(IBoxService boxService) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult GetAllBoxes()
    {
        var result = boxService.GetAllBoxes();
        var resultViewModel = new ResultViewModel(result.Obj.ConvertToViewModelResult(), result.Errors);
            
        if (!result.IsValid())
        {
            return BadRequest(resultViewModel);
        }
            
        return Ok(resultViewModel);
    }
}