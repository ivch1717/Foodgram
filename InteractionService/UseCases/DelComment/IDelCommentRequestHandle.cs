namespace UseCases.DelComment;

public interface IDelCommentRequestHandle
{
    public DelCommentResponse Handle(DelCommentRequest request);
}
