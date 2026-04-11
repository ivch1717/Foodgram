namespace UseCases.GetRecipesByUserId;

public class GetRecipesByUserIdRequestHandler : IGetRecipesByUserIdRequestHandler
{
    private readonly IGetRecipesByUserIdRepository _repository;

    public GetRecipesByUserIdRequestHandler(IGetRecipesByUserIdRepository repository)
    {
        _repository = repository;
    }

    public GetRecipesByUserIdResponse Handle(GetRecipesByUserIdRequest request)
    {
        var recipes = _repository.GetByUserId(request.UserId);
        return GetRecipesByUserIdMapper.ToResponse(recipes);
    }
}
