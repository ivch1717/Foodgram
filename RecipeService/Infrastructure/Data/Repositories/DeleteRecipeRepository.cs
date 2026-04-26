using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.Delete;

namespace Infrastructure.Data.Repositories;

internal sealed class DeleteRecipeRepository(RecipeServiceDbContext db) : IDeleteRecipeRepository
{
    public Recipe? GetById(Guid recipeId)
    {
        return db.Recipes.FirstOrDefault(x => x.Id == recipeId)?.ToEntity();
    }
    
    public void Delete(Guid recipeId)
    {
        var recipe = db.Recipes.FirstOrDefault(x => x.Id == recipeId);
        if (recipe == null) return;
        
        db.Recipes.Remove(recipe);
        db.SaveChanges();
    }
}
