using api.Dtos.Pet;

namespace api.Models;

public class Category
{
    public int Id { get; init; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public List<Pet> Pets { get; set; } = new List<Pet>();

}
