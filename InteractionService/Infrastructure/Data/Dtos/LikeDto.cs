namespace Infrastructure.Data.Dtos;

public record LikeDto(Guid UserId, Guid RecipeId, DateTime CreatedAt);