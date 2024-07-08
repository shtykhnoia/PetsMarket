using api.Dtos.Pet;
using api.Models;

namespace api.Mappers;

public static class PetMapper
{
    public static PetDto ToPetDto(this Pet petModel)
    {
        return new PetDto
        {
            Id = petModel.Id,
            Name = petModel.Name,
            Desc = petModel.Desc,
            Price = petModel.Price,
            CategoryId = petModel.CategoryId,
            //Category = petModel.Category,
            Img = petModel.Img,
            IsFavorite = petModel.IsFavorite
        };
    }

    public static Pet ToPetFromCreate(this CreatePetDto petDto, int categoryId)
    {
        return new Pet
        {
            Name = petDto.Name,
            Desc = petDto.Desc,
            Price = petDto.Price,
            CategoryId = categoryId
        };
    }
}