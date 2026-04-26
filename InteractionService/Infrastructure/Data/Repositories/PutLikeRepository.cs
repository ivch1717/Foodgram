using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.PutLike;

namespace Infrastructure.Data.Repositories;

internal sealed class PutLikeRepository(InteractionServiceDbContext db) : IPutLikeRepository
{
    public bool TryAdd(Like like)
    {
        var exists = db.Likes.Any(x => x.RecipeId == like.RecipetId && x.UserId == like.UserId);

        if (exists)
            return false;

        db.Likes.Add(like.ToDto());
        db.SaveChanges();
        return true;
    }
}