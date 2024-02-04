using Business.Abstracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _categoryService.GetAllAsync());
    }

    [HttpGet("GetAllProducts/{id}")]
    public async Task<IActionResult> GetAllProducts(Guid id)
    {
        return Ok(await _categoryService.GetAllProductsByCategoryIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] Category category)
    {
        return Ok(await _categoryService.AddAsync(category));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Category category)
    {
        return Ok(await _categoryService.UpdateAsync(category));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await _categoryService.DeleteByIdAsync(id);
        return Ok("Category deleted");
    }
}
