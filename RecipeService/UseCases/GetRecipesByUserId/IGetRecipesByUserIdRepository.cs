using Entities;

namespace UseCases.GetRecipesByUserId;

public interface IGetRecipesByUserIdRepository
{
    IReadOnlyCollection<Recipe> GetByUserId(Guid userId);
}
