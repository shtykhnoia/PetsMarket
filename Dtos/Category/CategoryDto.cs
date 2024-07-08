using api.Dtos.Pet;

namespace api.Dtos.Category;

public class CategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<PetDto> Pets { get; set; } = new List<PetDto>();
}
