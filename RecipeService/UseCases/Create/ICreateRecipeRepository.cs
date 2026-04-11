using Entities;

namespace UseCases.Create;

public interface ICreateRecipeRepository
{
    void Add(Recipe recipe);
}