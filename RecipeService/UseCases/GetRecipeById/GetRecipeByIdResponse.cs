namespace UseCases.GetRecipeById;

public sealed record GetRecipeByIdResponse(
    Guid Id,
    Guid UserId,
    int Price,
    int Calories,
    string Name,
    string Ingredients,
    string Instructions,
    DateTime DateCreated);
