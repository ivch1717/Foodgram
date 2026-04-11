namespace UseCases.GetLikesByUserId;

public interface IGetLikesByUserIdRequestHandle
{
    public GetLikesByUserIdResponse Handle(GetLikesByUserIdRequest request);
}
