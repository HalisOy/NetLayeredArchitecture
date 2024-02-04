using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController : Controller
{
    private readonly ICartService _cartService;
    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cartService.GetAllAsync());
    }

    [HttpGet("GetAllContents/{id}")]
    public async Task<IActionResult> GetAllContents(Guid id)
    {
        return Ok(await _cartService.GetAllProductsByCartIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddCartDto addCartDto)
    {
        return Ok(await _cartService.AddAsync(addCartDto));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await _cartService.DeleteByIdAsync(id);
        return Ok("Deleted cart");
    }
}
