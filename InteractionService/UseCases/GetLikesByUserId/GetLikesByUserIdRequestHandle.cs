namespace UseCases.GetLikesByUserId;

public class GetLikesByUserIdRequestHandle : IGetLikesByUserIdRequestHandle
{
    IGetLikesByUserIdRepository _repository;

    public GetLikesByUserIdRequestHandle(IGetLikesByUserIdRepository repository)
    {
        _repository = repository;
    }
    public GetLikesByUserIdResponse Handle(GetLikesByUserIdRequest request)
    {
        return GetLikesByUserIdMapper.ToResponse(_repository.GetLikesByUserId(request.UserId));
    }
}
