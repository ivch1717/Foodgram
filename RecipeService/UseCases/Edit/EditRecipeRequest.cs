namespace UseCases.Edit;

public sealed record EditRecipeRequest(
    Guid RecipeId,
    Guid UserId,
    int Price,
    int Calories,
    string Name,
    string Ingredients,
    string Instructions);
