namespace UseCases.GetRecipesByUserId;

public sealed record GetRecipesByUserIdItemResponse(
    Guid Id,
    Guid UserId,
    int Price,
    int Calories,
    string Name,
    string Ingredients,
    string Instructions,
    DateTime DateCreated);
