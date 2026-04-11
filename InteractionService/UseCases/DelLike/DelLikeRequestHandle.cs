namespace UseCases.DelLike;

public class DelLikeRequestHandle : IDelLikeRequestHandle
{
    IDelLikeRepository _repository;

    public DelLikeRequestHandle(IDelLikeRepository repository)
    {
        _repository = repository;
    }
    public DelLikeResponse Handle(DelLikeRequest request)
    {
        if (!_repository.Check(request.RecipeId, request.UserId))
        {
            throw new ArgumentException("Лайк не поставлен");
        }
        _repository.Delete(request.RecipeId, request.UserId);
        return new DelLikeResponse(request.RecipeId, request.UserId);
    }
}
