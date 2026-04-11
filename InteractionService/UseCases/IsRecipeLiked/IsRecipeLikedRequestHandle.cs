namespace UseCases.IsRecipeLiked;

public class IsRecipeLikedRequestHandle : IIsRecipeLikedRequestHandle
{
    private IIsRecipeLikedRepository _repository;

    public IsRecipeLikedRequestHandle(IIsRecipeLikedRepository repository)
    {
        _repository = repository;
    }
    public IsRecipeLikedResponse Handle(IsRecipeLikedRequest request)
    {
        return new IsRecipeLikedResponse(_repository.IsRecipeLiked(request.RecipeId, request.UserId));
    }
}
