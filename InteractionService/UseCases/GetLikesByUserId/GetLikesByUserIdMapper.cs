using Entities;

namespace UseCases.GetLikesByUserId;

public static class GetLikesByUserIdMapper
{
    public static GetLikesByUserIdResponse ToResponse(IReadOnlyCollection<Like> likes)
    {
        var items = likes
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new GetLikesByUserIdResponseObj(
                x.RecipetId,
                x.UserId,
                x.CreatedAt))
            .ToList();

        return new GetLikesByUserIdResponse(items);
    }
}
