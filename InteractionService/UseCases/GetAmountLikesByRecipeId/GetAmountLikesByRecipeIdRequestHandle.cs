namespace UseCases.GetAmountLikesByRecipeId;

public class GetAmountLikesByRecipeIdRequestHandle : IGetAmountLikesByRecipeIdRequestHandle
{
    IGetAmountLikesByRecipeIdRepository _repository;

    public GetAmountLikesByRecipeIdRequestHandle(IGetAmountLikesByRecipeIdRepository repository)
    {
        _repository = repository;
    }
    public GetAmountLikesByRecipeIdResponse Handle(GetAmountLikesByRecipeIdRequest request)
    {
        return new GetAmountLikesByRecipeIdResponse(
            _repository.GetAmountLikesByRecipeId(request.RecipeId));
    }
}
