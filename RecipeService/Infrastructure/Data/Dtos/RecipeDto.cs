namespace Infrastructure.Data.Dtos;

public sealed record RecipeDto(
    Guid Id,
    Guid UserId,
    int Price,
    int Calories,
    string Name,
    string Ingredients,
    string Instructions,
    DateTime DateCreated);