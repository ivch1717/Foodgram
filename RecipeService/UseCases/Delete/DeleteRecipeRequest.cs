namespace UseCases.Delete;

public sealed record DeleteRecipeRequest(
    Guid RecipeId,
    Guid UserId);
