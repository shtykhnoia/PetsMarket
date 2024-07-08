using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    
    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.Include(c => c.Pets).ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.Include(c => c.Pets).FirstOrDefaultAsync(i =>i.Id == id );
    }

    public async Task<Category> CreateAsync(Category categoryModel)
    {
        await _context.Categories.AddAsync(categoryModel);
        await _context.SaveChangesAsync();
        return categoryModel;
    }

    public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto)
    {
        var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCategory == null)
            return null;
        existingCategory.Name = categoryDto.Name;
        existingCategory.Description = categoryDto.Description;
        await _context.SaveChangesAsync();
        return existingCategory;
    }

    public async Task<Category?> DeleteAsync(int id)
    {
        var categoryModel = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        if (categoryModel == null)
            return null;
        _context.Categories.Remove(categoryModel);
        await _context.SaveChangesAsync();
        return categoryModel;
    }

    public Task<bool> CategoryExists(int id)
    {
        return _context.Categories.AnyAsync(c => c.Id == id);
    }
}