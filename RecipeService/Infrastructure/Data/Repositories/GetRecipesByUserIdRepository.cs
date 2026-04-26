using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.GetRecipesByUserId;

namespace Infrastructure.Data.Repositories;

internal sealed class GetRecipesByUserIdRepository(RecipeServiceDbContext db) : IGetRecipesByUserIdRepository
{
    public IReadOnlyCollection<Recipe> GetByUserId(Guid userId)
    {
        return db.Recipes
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.DateCreated)
            .Select(x => x.ToEntity())
            .ToList();
    }
}
