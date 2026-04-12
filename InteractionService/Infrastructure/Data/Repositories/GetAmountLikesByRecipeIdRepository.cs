using Infrastructure.Data.Db;
using UseCases.GetAmountLikesByRecipeId;

namespace Infrastructure.Data.Repositories;

internal sealed class GetAmountLikesByRecipeIdRepository(InteractionServiceDbContext db) : IGetAmountLikesByRecipeIdRepository
{
    public int GetAmountLikesByRecipeId(Guid recipeId)
    {
        return db.Likes.Count(x => x.RecipeId == recipeId);
    }
}