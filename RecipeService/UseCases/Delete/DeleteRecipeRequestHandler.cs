namespace UseCases.Delete;

public class DeleteRecipeRequestHandler : IDeleteRecipeRequestHandler
{
    private readonly IDeleteRecipeRepository _repository;

    public DeleteRecipeRequestHandler(IDeleteRecipeRepository repository)
    {
        _repository = repository;
    }

    public DeleteRecipeResponse Handle(DeleteRecipeRequest request)
    {
        var recipe = _repository.GetById(request.RecipeId);

        if (recipe is null)
            throw new InvalidOperationException("Recipe not found");

        if (recipe.UserId != request.UserId)
            throw new InvalidOperationException("User is not allowed to delete this recipe");

        _repository.Delete(request.RecipeId);

        return new DeleteRecipeResponse(request.RecipeId);
    }
}
