namespace UseCases.CreateReport;

public interface IDeleteCommentRepository
{
    void DeleteComment(Guid commentId, Guid userId);
}