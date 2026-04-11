namespace UseCases.GetCommentsByRecipeId;

public class GetCommentsByRecipeIdRequestHandle : IGetCommentsByRecipeIdRequestHandle
{
    IGetCommentsByRecipeIdRepository _repository;

    public GetCommentsByRecipeIdRequestHandle(IGetCommentsByRecipeIdRepository repository)
    {
        _repository = repository;
    }
    public GetCommentsByRecipeIdResponse Handle(GetCommentsByRecipeIdRequest request)
    {
        return GetCommentsByRecipeIdMapper.ToResponse(
            _repository.GetCommentsByRecipeId(request.RecipeId));
    }
}
