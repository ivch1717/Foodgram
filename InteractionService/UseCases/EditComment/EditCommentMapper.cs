using Entities;
namespace UseCases.EditComment;

public static class EditCommentMapper
{
    public static Comment ToEntities(EditCommentRequest request, DateTime dt)
    {
        return new Comment(request.CommentId, request.RecipeId, request.UserId, dt, request.Text);
    }
}
