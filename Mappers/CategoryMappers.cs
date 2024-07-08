using api.Dtos.Category;
using api.Models;

namespace api.Mappers;

public static class CategoryMappers
{
    public static CategoryDto ToCategoryDto(this Category categoryModel)
    {
        return new CategoryDto
        {
            Id = categoryModel.Id,
            
            Name = categoryModel.Name,
            
            Description = categoryModel.Description,
            
            Pets = categoryModel.Pets.Select(c => c.ToPetDto()).ToList()
        };
    }

    public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto categoryDto)
    {
        return new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
        };
    }

    public static Category ToCategoryFromUpdateDto(this UpdateCategoryRequestDto categoryDto)
    {
        return new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
        };
    }
}