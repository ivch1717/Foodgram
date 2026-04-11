namespace UseCases.Create;

public sealed record CreateRecipeRequest(
    Guid UserId,
    int Price,
    int Calories,
    string Name,
    string Ingredients,
    string Instructions,
    DateTime DateCreated);