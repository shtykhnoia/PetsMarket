namespace api.Dtos.Pet;

public class CreatePetDto
{
    public string Name { get; set; } = string.Empty;

    public string Desc { set; get; } = string.Empty;

    public int Price { get; set; }
}