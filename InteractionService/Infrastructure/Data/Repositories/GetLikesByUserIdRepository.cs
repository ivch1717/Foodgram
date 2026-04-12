using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.GetLikesByUserId;

namespace Infrastructure.Data.Repositories;

internal sealed class GetLikesByUserIdRepository(InteractionServiceDbContext db) : IGetLikesByUserIdRepository
{
    public IReadOnlyCollection<Like> GetLikesByUserId(Guid userId)
    {
        return db.Likes
            .Where(x => x.UserId == userId)
            .Select(x => x.ToEntity())
            .ToList();
    }
}