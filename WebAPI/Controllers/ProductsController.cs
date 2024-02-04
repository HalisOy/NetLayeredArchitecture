using Business.Abstracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productService.GetAllAsync());
    }

    [HttpGet("GetAllWithCategoryAndUser")]
    public async Task<IActionResult> GetAllWithCategoryAndUser()
    {
        return Ok(await _productService.GetAllWithCategoryAndUserAsync());
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddProductDto addProductDto)
    {
        return Ok(await _productService.AddAsync(addProductDto));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
    {
        return Ok(await _productService.UpdateAsync(updateProductDto));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await _productService.DeleteByIdAsync(id);
        return Ok("Product deleted");
    }
}
