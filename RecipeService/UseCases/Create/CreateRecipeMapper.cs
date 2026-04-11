using Entities;
namespace UseCases.Create;

public static class CreateRecipeMapper
{
    public static Recipe ToEntity(CreateRecipeRequest request, Guid recipeId)
    {
        return new Recipe(recipeId, 
            request.UserId, 
            request.Price, 
            request.Calories, 
            request.Name, 
            request.Ingredients, 
            request.Instructions, 
            request.DateCreated);
    }

    public static CreateRecipeResponse ToResponse(Recipe recipe)
    {
        return new CreateRecipeResponse(recipe.Id);
    }
}