namespace Infrastructure.Data.Dtos;

public record CommentDto(Guid Id, Guid UserId, Guid RecipeId, DateTime CreatedAt, string Text);