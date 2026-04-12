using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.GetRecipeById;

namespace Infrastructure.Data.Repositories;

internal sealed class GetRecipeByIdRepository(RecipeServiceDbContext db) : IGetRecipeByIdRepository
{
    public Recipe? GetById(Guid recipeId)
    {
        return db.Recipes
            .FirstOrDefault(x => x.Id == recipeId)?
            .ToEntity();
    }
}
