using Entities;

namespace UseCases.Delete;

public interface IDeleteRecipeRepository
{
    Recipe? GetById(Guid recipeId);
    void Delete(Guid recipeId);
}
