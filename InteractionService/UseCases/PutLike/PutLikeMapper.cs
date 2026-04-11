using Entities;
namespace UseCases.PutLike;

public static class PutLikeMapper
{
    public static Like ToEntity(this PutLikeRequest request)
    {
        return new Like(request.UserId, request.RecipeId, request.Date);
    }

    public static PutLikeResponse ToResponse(Like like, bool added)
    {
        return new PutLikeResponse(like.UserId, like.RecipetId, added);
    }
}