namespace UseCases.GetRecipesByUserId;

public sealed record GetRecipesByUserIdResponse(
    IReadOnlyCollection<GetRecipesByUserIdItemResponse> Recipes);
