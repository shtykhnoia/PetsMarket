using api.Dtos.Category;
using api.Models;

namespace api.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    
    Task<Category?> GetByIdAsync(int id);
    
    Task<Category> CreateAsync(Category categoryModel);

    Task<Category?> UpdateAsync(int id, UpdateCategoryRequestDto categoryDto);

    Task<Category?> DeleteAsync(int id);

    Task<bool> CategoryExists(int id);

}

