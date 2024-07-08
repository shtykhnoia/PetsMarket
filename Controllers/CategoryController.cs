using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[Route("api/category")] 
[ApiController]

public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ICategoryRepository _categoryRepo;
    
    public CategoryController(ApplicationDbContext context, ICategoryRepository categoryRepo)
    {
        _context = context;
        _categoryRepo = categoryRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var categories = await _categoryRepo.GetAllAsync();
        var categoryDto = categories.Select(s => s.ToCategoryDto());
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var category = await _categoryRepo.GetByIdAsync(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category.ToCategoryDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var categoryModel = categoryDto.ToCategoryFromCreateDto();
        await _categoryRepo.CreateAsync(categoryModel);
        return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto categoryDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var categoryModel = await _categoryRepo.UpdateAsync(id, categoryDto);
        if (categoryModel == null)
        {
            return NotFound();
        }
        
        return Ok(categoryModel.ToCategoryDto());
    }

    [HttpDelete]
    [Route("{id:int}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var categoryModel = await _categoryRepo.DeleteAsync(id);
        if (categoryModel == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}