namespace UseCases.EditComment;

public interface IEditCommentRequestHandle
{
    public EditCommentResponse Handle(EditCommentRequest request);
}
