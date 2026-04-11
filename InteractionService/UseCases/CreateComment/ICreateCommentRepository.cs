using Entities;

namespace UseCases.CreateComment;

public interface ICreateCommentRepository
{
    void AddComment(Comment comment);
}
