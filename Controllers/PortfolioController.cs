using api.Extentions;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/portfolio")]
[ApiController]


public class PortfolioController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IPetRepository _petRepository;
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioController(UserManager<AppUser> userManager, IPetRepository petRepository, IPortfolioRepository portfolioRepository)
    {
        _userManager = userManager;
        _petRepository = petRepository;
        _portfolioRepository = portfolioRepository;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserPortfolio()
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
        return Ok(userPortfolio);
    }

    [HttpPost]
    [Authorize]

    public async Task<IActionResult> AddPortfolio(string name)
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var pet = await _petRepository.GetByNameAsync(name);

        if (pet == null) return BadRequest("Pet not found");

        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);
        if (userPortfolio.Any(p => p.Name.ToLower() == name.ToLower()))
            return BadRequest("cannot add pet to portfolio");
        var portfolioModel = new Portfolio
        {
            PetId = pet.Id,
            AppUserId = appUser.Id
        };

        await _portfolioRepository.CreateAsync(portfolioModel);
        return Created();
    }
}