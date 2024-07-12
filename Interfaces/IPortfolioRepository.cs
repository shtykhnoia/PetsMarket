using api.Models;

namespace api.Interfaces;

public interface IPortfolioRepository
{
    Task<List<Pet>> GetUserPortfolio(AppUser user);

    Task<Portfolio> CreateAsync(Portfolio portfolio);
}