using Entities;
using UseCases.CreateComment;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;

namespace Infrastructure.Data.Repositories;

internal sealed class CreateCommentRepository(InteractionServiceDbContext db) : ICreateCommentRepository
{
    public void AddComment(Comment comment)
    {
        db.Comments.Add(comment.ToDto());
        db.SaveChanges();
    }
}