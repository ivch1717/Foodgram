namespace UseCases.Edit;

public sealed record EditRecipeResponse(
    Guid Id,
    Guid UserId,
    int Price,
    int Calories,
    string Name,
    string Ingredients,
    string Instructions,
    DateTime DateCreated);
