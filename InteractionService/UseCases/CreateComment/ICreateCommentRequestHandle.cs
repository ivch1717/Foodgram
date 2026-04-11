namespace UseCases.CreateComment;

public interface ICreateCommentRequestHandle
{
    public CreateCommentResponse Handle(CreateCommentRequest request);
}
