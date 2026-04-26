using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.GetCommentsByUserId;

namespace Infrastructure.Data.Repositories;

internal sealed class GetCommentsByUserIdRepository(InteractionServiceDbContext db) : IGetCommentsByUserIdRepository
{
    public IReadOnlyCollection<Comment> GetCommentsByUserId(Guid userId)
    {
        return db.Comments
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => x.ToEntity())
            .ToList();
    }
}