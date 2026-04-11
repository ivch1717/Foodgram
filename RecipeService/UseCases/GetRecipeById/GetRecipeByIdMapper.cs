using Entities;

namespace UseCases.GetRecipeById;

public static class GetRecipeByIdMapper
{
    public static GetRecipeByIdResponse ToResponse(Recipe recipe)
    {
        return new GetRecipeByIdResponse(
            recipe.Id,
            recipe.UserId,
            recipe.Price,
            recipe.Calories,
            recipe.Name,
            recipe.Ingredients,
            recipe.Instructions,
            recipe.DateCreated);
    }
}
