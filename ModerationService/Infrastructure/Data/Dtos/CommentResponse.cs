namespace Infrastructure.Data.Dtos;

public record CommentResponse(Guid Id, Guid UserId, Guid RecipeId, DateTime CreatedAt, string Text);