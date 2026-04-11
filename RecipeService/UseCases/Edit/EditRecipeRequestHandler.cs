using Entities;

namespace UseCases.Edit;

public class EditRecipeRequestHandler : IEditRecipeRequestHandler
{
    private readonly IEditRecipeRepository _repository;

    public EditRecipeRequestHandler(IEditRecipeRepository repository)
    {
        _repository = repository;
    }

    public EditRecipeResponse Handle(EditRecipeRequest request)
    {
        var recipe = _repository.GetById(request.RecipeId);

        if (recipe is null)
            throw new InvalidOperationException("Recipe not found");

        if (recipe.UserId != request.UserId)
            throw new InvalidOperationException("User is not allowed to edit this recipe");

        var updatedRecipe = EditRecipeMapper.ToEntity(request,  recipe.DateCreated); 

        _repository.Update(updatedRecipe);

        return EditRecipeMapper.ToResponse(updatedRecipe);
    }
}
