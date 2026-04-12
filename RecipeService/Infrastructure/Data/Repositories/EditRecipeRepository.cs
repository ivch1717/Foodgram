using Entities;
using Infrastructure.Data.Db;
using UseCases.Edit;
using Infrastructure.Data.Mappers;

namespace Infrastructure.Data.Repositories;

internal sealed class EditRecipeRepository(RecipeServiceDbContext db) : IEditRecipeRepository
{
    public Recipe? GetById(Guid recipeId)
    {
        return db.Recipes.FirstOrDefault(x => x.Id == recipeId)?.ToEntity();
    }

    public void Update(Recipe recipe)
    {
        db.Recipes.Update(recipe.ToDto());
        db.SaveChanges();
    }
}
