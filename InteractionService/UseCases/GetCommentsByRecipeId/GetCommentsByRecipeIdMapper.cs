using Entities;

namespace UseCases.GetCommentsByRecipeId;

public static class GetCommentsByRecipeIdMapper
{
    public static GetCommentsByRecipeIdResponse ToResponse(IReadOnlyCollection<Comment> comments)
    {
        return new GetCommentsByRecipeIdResponse(
            comments.OrderByDescending(x => x.CreatedAt)
                .Select(x => new GetCommentsByRecipeIdResponseObj(x.Id, x.RecipeId, x.UserId,x.Text, x.CreatedAt))
            .ToList());
    }
}
