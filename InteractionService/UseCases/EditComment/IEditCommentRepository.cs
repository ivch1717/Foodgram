using Entities;

namespace UseCases.EditComment;

public interface IEditCommentRepository
{
    Comment? GetComment(Guid commentId);
    void UpdateComment(Comment comment);
}
