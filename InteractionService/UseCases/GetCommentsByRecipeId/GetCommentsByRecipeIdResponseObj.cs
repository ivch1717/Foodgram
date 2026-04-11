namespace UseCases.GetCommentsByRecipeId;

public sealed record GetCommentsByRecipeIdResponseObj(Guid CommentId, Guid RecipeId, Guid UserId, string Text, DateTime CreatedAt);