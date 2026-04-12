using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.Create;

namespace Infrastructure.Data.Repositories;

internal sealed class CreateRecipeRepository(RecipeServiceDbContext db) : ICreateRecipeRepository
{
    public void Add(Recipe recipe)
    {
        db.Recipes.Add(recipe.ToDto());
        db.SaveChanges();
    }
}
