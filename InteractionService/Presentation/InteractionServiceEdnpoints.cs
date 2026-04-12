using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Presentation.Endpoints;
namespace Presentation;

public static class InteractionServiceEndpoints
{
    public static WebApplication MapWebApplication(this WebApplication app)
    {
        app.MapGroup("/likes")
            .WithTags("Likes")
            .MapDelLike()
            .MapGetLikesByUserId()
            .MapGetAmountLikesByRecipeId()
            .MapIsRecipeLiked()
            .MapPutLike();

        app.MapGroup("/comments")
            .WithTags("Comments")
            .MapDelComment()
            .MapEditComment()
            .MapCreateComment()
            .MapGetAmountCommentsByRecipeId()
            .MapGetCommentsByRecipeId()
            .MapGetCommentsByUserId();

        return app;
    }
}