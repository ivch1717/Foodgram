using Entities;
namespace UseCases.CreateComment;

public static class CreateCommentMapper
{
    public static Comment ToEntities(CreateCommentRequest request, Guid commentID)
    {
        return new Comment(commentID, request.UserId, request.RecipeId, request.CreatedAt, request.Text);
    }
}
