using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.CheckContentForModeration;

namespace Presentation.Endpoints;

public static class CheckContentForModerationEndpoint
{
    public static RouteGroupBuilder MapCheckContentForModeration(this RouteGroupBuilder group)
    {
        group.MapPost("/content", (CheckContentForModerationRequest request, CheckContentForModerationRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(request);
                    return Results.Ok(response);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("CheckContentForModeration")
            .WithSummary("Check Content For Moderation")
            .WithDescription("Проверка контента для модерации")
            .WithOpenApi()
            .Produces<CheckContentForModerationResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}