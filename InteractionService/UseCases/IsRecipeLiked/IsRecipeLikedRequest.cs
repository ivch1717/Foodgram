namespace UseCases.IsRecipeLiked;

public sealed record IsRecipeLikedRequest(Guid RecipeId, Guid UserId);
