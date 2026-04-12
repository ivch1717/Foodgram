using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.PutLike;

namespace Presentation.Endpoints;

public static class PutLikeEndpoint
{
    public static RouteGroupBuilder MapPutLike(this RouteGroupBuilder group)
    {
        group.MapPost("", (PutLikeRequest request, IPutLikeRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(request);
                    return Results.Created($"/likes?recipeId={response.RecipeId}&userId={response.UserId}", response);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("PutLike")
            .WithSummary("Put Like")
            .WithDescription("Постановка лайка рецепту")
            .WithOpenApi()
            .Produces<PutLikeResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
