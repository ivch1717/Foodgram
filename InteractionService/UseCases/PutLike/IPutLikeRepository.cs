using Entities;

namespace UseCases.PutLike;

public interface IPutLikeRepository
{
    bool TryAdd(Like like);
}