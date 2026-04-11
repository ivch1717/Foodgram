using Entities;

namespace UseCases.DelComment;

public interface IDelCommentRepository
{
    Comment? GetComment(Guid commentId);
    void DeleteComment(Guid commentId);
}
