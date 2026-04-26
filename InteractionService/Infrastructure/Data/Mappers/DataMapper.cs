using Entities;
using Infrastructure.Data.Dtos;

namespace Infrastructure.Data.Mappers;

public static class DataMapper
{
    public static CommentDto ToDto(this Comment comment)
    {
        return new CommentDto(
            comment.Id,
            comment.UserId,
            comment.RecipeId,
            comment.CreatedAt,
            comment.Text);
    }

    public static Comment ToEntity(this CommentDto dto)
    {
        return new Comment(
            dto.Id,
            dto.UserId,
            dto.RecipeId,
            dto.CreatedAt,
            dto.Text);
    }

    public static LikeDto ToDto(this Like like)
    {
        return new LikeDto(like.UserId, like.RecipetId, like.CreatedAt);
    }

    public static Like ToEntity(this LikeDto dto)
    {
        return new Like(
            dto.UserId,
            dto.RecipeId,
            dto.CreatedAt);
    }
}