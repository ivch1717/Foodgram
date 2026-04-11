namespace UseCases.PutLike;

public class PutLikeRequestHandle : IPutLikeRequestHandle
{
    IPutLikeRepository _repository;
    public PutLikeRequestHandle(IPutLikeRepository repository)
    {
        _repository = repository;
    }

    public PutLikeResponse Handle(PutLikeRequest request)
    {
        var likes = PutLikeMapper.ToEntity(request);
        bool res = _repository.TryAdd(likes);
        return PutLikeMapper.ToResponse(likes, res);
    }
}