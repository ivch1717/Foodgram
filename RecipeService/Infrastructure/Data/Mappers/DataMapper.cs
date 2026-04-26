using Entities;
using Infrastructure.Data.Dtos;

namespace Infrastructure.Data.Mappers;

public static class DataMapper
{
    public static RecipeDto ToDto(this Recipe recipe)
    {
        return new RecipeDto(
            recipe.Id,
            recipe.UserId,
            recipe.Price,
            recipe.Calories,
            recipe.Name,
            recipe.Ingredients,
            recipe.Instructions,
            recipe.DateCreated);
    }

    public static Recipe ToEntity(this RecipeDto dto)
    {
        return new Recipe(
            dto.Id,
            dto.UserId,
            dto.Price,
            dto.Calories,
            dto.Name,
            dto.Ingredients,
            dto.Instructions,
            dto.DateCreated);
    }
}