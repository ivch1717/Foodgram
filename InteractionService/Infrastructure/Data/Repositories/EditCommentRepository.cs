using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using Microsoft.EntityFrameworkCore;
using UseCases.EditComment;

namespace Infrastructure.Data.Repositories;

internal sealed class EditCommentRepository(InteractionServiceDbContext db) : IEditCommentRepository
{
    public Comment? GetComment(Guid commentId)
    {
        return db.Comments
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == commentId)?
            .ToEntity();
    }

    public void UpdateComment(Comment comment)
    {
        db.Comments.Update(comment.ToDto());
        db.SaveChanges();
    }
}