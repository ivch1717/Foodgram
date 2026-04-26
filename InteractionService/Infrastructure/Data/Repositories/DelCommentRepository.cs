using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.DelComment;

namespace Infrastructure.Data.Repositories;

internal sealed class DelCommentRepository(InteractionServiceDbContext db) : IDelCommentRepository
{
    public Comment? GetComment(Guid commentId)
    {
        return db.Comments
            .FirstOrDefault(x => x.Id == commentId)?
            .ToEntity();
    }

    public void DeleteComment(Guid commentId)
    {
        var comment = db.Comments.FirstOrDefault(x => x.Id == commentId);

        if (comment is null)
            return;

        db.Comments.Remove(comment);
        db.SaveChanges();
    }
}