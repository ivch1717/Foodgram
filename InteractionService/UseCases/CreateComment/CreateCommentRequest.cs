namespace UseCases.CreateComment;

public sealed record CreateCommentRequest(Guid RecipeId, Guid UserId, DateTime CreatedAt, string Text);
