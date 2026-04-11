using Entities;

namespace UseCases.GetCommentsByUserId;

public interface IGetCommentsByUserIdRepository
{
    IReadOnlyCollection<Comment> GetCommentsByUserId(Guid userId);
}
