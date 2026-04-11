namespace UseCases.DelComment;

public class DelCommentRequestHandle : IDelCommentRequestHandle
{
    IDelCommentRepository _repository;

    public DelCommentRequestHandle(IDelCommentRepository repository)
    {
        _repository = repository;
    }
    public DelCommentResponse Handle(DelCommentRequest request)
    {
        var comment = _repository.GetComment(request.CommentId);
        if (comment is null)
        {
            throw new ArgumentNullException("такого коментария нет");
        }

        if (comment.UserId != request.UserId)
        {
            throw new ArgumentException("нет прав удалять комаентарий");
        }
        _repository.DeleteComment(request.CommentId);
        return new DelCommentResponse(request.CommentId);
    }
}
