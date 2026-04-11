namespace UseCases.GetCommentsByUserId;

public sealed record GetCommentsByUserIdResponseObj(Guid CommentId, Guid RecipeId, Guid UserId, string Text, DateTime CreatedAt);
