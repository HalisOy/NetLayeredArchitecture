using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController :Controller
{
    private readonly IOrderService _orderService;
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _orderService.GetAllAsync());
    }

    //[HttpGet("GetAllContents/{id}")]
    //public async Task<IActionResult> GetAllContents(Guid id)
    //{
    //    return Ok(await _orderService.getall(id));
    //}

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddOrderDto addOrderDto)
    {
        return Ok(await _orderService.AddAsync(addOrderDto));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await _orderService.DeleteByIdAsync(id);
        return Ok("Deleted order");
    }
}
