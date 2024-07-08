using api.Models;

namespace api.Dtos.Pet;

public class PetDto
{
    public int Id { get; set; }
    
    //public Models.Category? Category { get; set; }
    
    public int CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Desc { set; get; } = string.Empty;

    public int Price { get; set; }

    public string Img { get; set; } = string.Empty;

    public bool IsFavorite { get; set; }
    
}