using Entities;

namespace UseCases.GetRecipeById;

public interface IGetRecipeByIdRepository
{
    Recipe? GetById(Guid recipeId);
}
