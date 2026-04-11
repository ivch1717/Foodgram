namespace UseCases.EditComment;

public sealed record EditCommentRequest(Guid CommentId, Guid RecipeId, Guid UserId, string Text);
