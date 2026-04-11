namespace UseCases.EditComment;

public class EditCommentRequestHandle : IEditCommentRequestHandle
{
    IEditCommentRepository _repository;

    public EditCommentRequestHandle(IEditCommentRepository repository)
    {
        _repository = repository;
    }
    public EditCommentResponse Handle(EditCommentRequest request)
    {
        var comment = _repository.GetComment(request.CommentId);
        if (comment is null)
        {
            throw new ArgumentNullException("Comment not found");
        }
        
        if (comment.UserId != request.UserId)
        {
            throw new ArgumentException("user не совпадает");
        }
        _repository.UpdateComment(EditCommentMapper.ToEntities(request, comment.CreatedAt));
        return new EditCommentResponse(request.CommentId);
    }
}
