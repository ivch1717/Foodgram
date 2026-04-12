using Infrastructure.Data.Db;
using UseCases.DelLike;

namespace Infrastructure.Data.Repositories;

internal sealed class DelLikeRepository(InteractionServiceDbContext db) : IDelLikeRepository
{
    public bool Check(Guid recipeId, Guid userId)
    {
        return db.Likes.Any(x => x.RecipeId == recipeId && x.UserId == userId);
    }

    public void Delete(Guid recipeId, Guid userId)
    {
        var like = db.Likes.FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);

        if (like is null)
            return;

        db.Likes.Remove(like);
        db.SaveChanges();
    }
}