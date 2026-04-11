namespace UseCases.GetRecipeById;

public class GetRecipeByIdRequestHandler : IGetRecipeByIdRequestHandler
{
    private readonly IGetRecipeByIdRepository _repository;

    public GetRecipeByIdRequestHandler(IGetRecipeByIdRepository repository)
    {
        _repository = repository;
    }

    public GetRecipeByIdResponse Handle(GetRecipeByIdRequest request)
    {
        var recipe = _repository.GetById(request.RecipeId);

        if (recipe is null)
            throw new InvalidOperationException("Recipe not found");

        return GetRecipeByIdMapper.ToResponse(recipe);
    }
}
