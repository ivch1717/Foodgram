namespace UseCases.GetCommentsByUserId;

public interface IGetCommentsByUserIdRequestHandle
{
    public GetCommentsByUserIdResponse Handle(GetCommentsByUserIdRequest request);
}
