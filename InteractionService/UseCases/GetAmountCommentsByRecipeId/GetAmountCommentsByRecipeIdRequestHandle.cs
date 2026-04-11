namespace UseCases.GetAmountCommentsByRecipeId;

public class GetAmountCommentsByRecipeIdRequestHandle : IGetAmountCommentsByRecipeIdRequestHandle
{
    IGetAmountCommentsByRecipeIdRepository _repository;

    public GetAmountCommentsByRecipeIdRequestHandle(IGetAmountCommentsByRecipeIdRepository repository)
    {
        _repository = repository;
    }

    public GetAmountCommentsByRecipeIdResponse Handle(GetAmountCommentsByRecipeIdRequest request)
    {
        return new GetAmountCommentsByRecipeIdResponse(
            _repository.GetAmountCommentsByRecipeId(request.RecipeId));
    }
}
