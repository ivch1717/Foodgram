using Entities;
using System.Linq;

namespace UseCases.GetCommentsByUserId;

public static class GetCommentsByUserIdMapper
{
    public static GetCommentsByUserIdResponse ToResponse(IReadOnlyCollection<Comment> comments)
    {
        return new GetCommentsByUserIdResponse(
            comments.OrderByDescending(x => x.CreatedAt)
                .Select(x => new GetCommentsByUserIdResponseObj(
                    x.Id,
                    x.RecipetId,
                    x.UserId,
                    x.Text,
                    x.CreatedAt))
                .ToList());
    }
}
