using api.Helpers;
using api.Models;

namespace api.Interfaces;

public interface IPetRepository
{
    Task<List<Pet>> GetAllAsync(QueryObject query);
    Task<Pet?> GetByIdAsync(int id);
    Task<Pet> CreateAsync(Pet petModel);

    Task<Pet?> DeleteAsync(int id);
}