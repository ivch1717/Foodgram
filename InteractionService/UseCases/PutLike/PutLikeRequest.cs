namespace UseCases.PutLike;

public sealed record PutLikeRequest(Guid RecipeId, Guid UserId, DateTime Date);