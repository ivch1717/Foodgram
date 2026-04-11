using Entities;

namespace UseCases.GetRecipesByUserId;

public static class GetRecipesByUserIdMapper
{
    public static GetRecipesByUserIdItemResponse ToItemResponse(Recipe recipe)
    {
        return new GetRecipesByUserIdItemResponse(
            recipe.Id,
            recipe.UserId,
            recipe.Price,
            recipe.Calories,
            recipe.Name,
            recipe.Ingredients,
            recipe.Instructions,
            recipe.DateCreated);
    }

    public static GetRecipesByUserIdResponse ToResponse(IEnumerable<Recipe> recipes)
    {
        var items = recipes
            .Select(ToItemResponse)
            .ToList();

        return new GetRecipesByUserIdResponse(items);
    }
}
