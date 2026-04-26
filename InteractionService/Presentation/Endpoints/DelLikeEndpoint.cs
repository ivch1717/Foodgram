using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UseCases.DelLike;

namespace Presentation.Endpoints;

public static class DelLikeEndpoint
{
    public static RouteGroupBuilder MapDelLike(this RouteGroupBuilder group)
    {
        group.MapDelete("", ([FromBody] DelLikeRequest request, IDelLikeRequestHandle handler) =>
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
                catch (InvalidOperationException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("DelLike")
            .WithSummary("Delete Like")
            .WithDescription("Удаление лайка")
            .WithOpenApi()
            .Produces<DelLikeResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
