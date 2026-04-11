using Entities;
using UseCases.Create;

namespace UseCases.Edit;

public static class EditRecipeMapper
{
    public static Recipe ToEntity(EditRecipeRequest request, DateTime dt)
    {
        return new Recipe(
            request.RecipeId,
            request.UserId,
            request.Price,
            request.Calories,
            request.Name,
            request.Ingredients,
            request.Instructions,
            dt);
    }
    
    public static EditRecipeResponse ToResponse(Recipe recipe)
    {
        return new EditRecipeResponse(
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
