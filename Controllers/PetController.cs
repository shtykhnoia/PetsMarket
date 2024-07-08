using api.Dtos.Pet;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[Route("api/pet")]
[ApiController]

public class PetController : ControllerBase
{
    private readonly IPetRepository _petRepo;
    private readonly ICategoryRepository _categoryRepository;

    public PetController(IPetRepository petRepo, ICategoryRepository categoryRepository)
    {
        _petRepo = petRepo;
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var pets = await _petRepo.GetAllAsync(query);

        var petDto = pets.Select(s => s.ToPetDto());
        
        return Ok(petDto);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var pet = await _petRepo.GetByIdAsync(id);
        if (pet == null)
        {
            return NotFound();
        }

        return Ok(pet.ToPetDto());
    }

    [HttpPost("{categoryId}")]
    public async Task<IActionResult> Create([FromRoute] int categoryId, CreatePetDto petDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (!await _categoryRepository.CategoryExists(categoryId))
        {
            return BadRequest("Category does not exist");
        }
        var petModel = petDto.ToPetFromCreate(categoryId);
        await _petRepo.CreateAsync(petModel);

        return CreatedAtAction(nameof(GetById), new { id = petModel }, petModel.ToPetDto());
    }

    [HttpDelete]
    [Route("{id:int}")]

    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var petModel = await _petRepo.DeleteAsync(id);

        if (petModel == null)
        {
            return NotFound();
        }
        
        return Ok(petModel);
    }
}