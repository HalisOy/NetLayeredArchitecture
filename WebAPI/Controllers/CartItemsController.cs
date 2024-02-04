using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CartItemsController : Controller
{
    private readonly ICartItemService _cartItemService;
    public CartItemsController(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _cartItemService.GetAllAsync());
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddCartItemDto addCartItemDto)
    {
        return Ok(await _cartItemService.AddAsync(addCartItemDto));
    }

    [HttpPut("AddQuantity/{id}")]
    public async Task<IActionResult> AddQuantity(Guid id)
    {
        await _cartItemService.AddQuantityAsync(id);
        return Ok();
    }

    [HttpPut("DecreaseQuantity/{id}")]
    public async Task<IActionResult> DecreaseQuantity(Guid id)
    {
        await _cartItemService.DecreaseQuantityAsync(id);
        return Ok();
    }
}
