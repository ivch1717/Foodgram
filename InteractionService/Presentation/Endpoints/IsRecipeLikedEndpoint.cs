using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.IsRecipeLiked;

namespace Presentation.Endpoints;

public static class IsRecipeLikedEndpoint
{
    public static RouteGroupBuilder MapIsRecipeLiked(this RouteGroupBuilder group)
    {
        group.MapGet("", (Guid recipeId, Guid userId, IIsRecipeLikedRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(new IsRecipeLikedRequest(recipeId, userId));
                    return Results.Ok(response);
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
            .WithName("IsRecipeLiked")
            .WithSummary("Is Recipe Liked")
            .WithDescription("Проверка, поставил ли пользователь лайк рецепту")
            .WithOpenApi()
            .Produces<IsRecipeLikedResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
