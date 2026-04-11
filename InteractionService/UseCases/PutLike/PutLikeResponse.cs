namespace UseCases.PutLike;

public sealed record PutLikeResponse(Guid RecipeId, Guid UserId, bool added);