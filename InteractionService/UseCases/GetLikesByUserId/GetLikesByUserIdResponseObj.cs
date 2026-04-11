namespace UseCases.GetLikesByUserId;

public sealed record GetLikesByUserIdResponseObj(Guid RecipeId, Guid UserId, DateTime CreatedAt);