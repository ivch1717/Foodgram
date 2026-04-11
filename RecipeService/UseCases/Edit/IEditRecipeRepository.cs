using Entities;

namespace UseCases.Edit;

public interface IEditRecipeRepository
{
    Recipe? GetById(Guid recipeId);
    void Update(Recipe recipe);
}
