using Infrastructure.Data.Db;
using UseCases.GetAmountCommentsByRecipeId;

namespace Infrastructure.Data.Repositories;

internal sealed class GetAmountCommentsByRecipeIdRepository(InteractionServiceDbContext db) : IGetAmountCommentsByRecipeIdRepository
{
    public int GetAmountCommentsByRecipeId(Guid recipeId)
    {
        return db.Comments.Count(x => x.RecipeId == recipeId);
    }
}