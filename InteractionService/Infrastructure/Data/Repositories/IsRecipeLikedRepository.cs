using Infrastructure.Data.Db;
using UseCases.IsRecipeLiked;

namespace Infrastructure.Data.Repositories;

internal sealed class IsRecipeLikedRepository(InteractionServiceDbContext db) : IIsRecipeLikedRepository
{
    public bool IsRecipeLiked(Guid recipeId, Guid userId)
    {
        return db.Likes.Any(x => x.RecipeId == recipeId && x.UserId == userId);
    }
}