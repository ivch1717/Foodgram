using Entities;

namespace UseCases.GetLikesByUserId;

public interface IGetLikesByUserIdRepository
{
    IReadOnlyCollection<Like>  GetLikesByUserId(Guid userId);
}
