using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class PetRepository : IPetRepository
{
    private readonly ApplicationDbContext _context;
    
    public PetRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Pet>> GetAllAsync(QueryObject query)
    {
        var pets =  _context.Pets.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.CategoryName))
        {
            pets = pets.Where(p => p.Category.Name.Contains(query.CategoryName));
        }

        return await pets.ToListAsync();
    }

    public async Task<Pet?> GetByIdAsync([FromRoute] int id)
    {
        return await _context.Pets.FindAsync(id);
    }

    public async Task<Pet> CreateAsync(Pet petModel)
    {
        await _context.Pets.AddAsync(petModel);
        await _context.SaveChangesAsync();
        return petModel;
    }

    public async Task<Pet?> DeleteAsync(int id)
    {
        var petModel = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
        if (petModel == null)
        {
            return null;
        }
        _context.Pets.Remove((petModel));
        await _context.SaveChangesAsync();
        return petModel;
    }

    public async Task<Pet?> GetByNameAsync(string name)
    {
        return await _context.Pets.FirstOrDefaultAsync(p => p.Name == name);
    }
}