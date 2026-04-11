namespace UseCases.GetCommentsByUserId;

public class GetCommentsByUserIdRequestHandle : IGetCommentsByUserIdRequestHandle
{
    IGetCommentsByUserIdRepository _repository;

    public GetCommentsByUserIdRequestHandle(IGetCommentsByUserIdRepository repository)
    {
        _repository = repository;
    }

    public GetCommentsByUserIdResponse Handle(GetCommentsByUserIdRequest request)
    {
        return GetCommentsByUserIdMapper.ToResponse(
            _repository.GetCommentsByUserId(request.UserId));
    }
}
