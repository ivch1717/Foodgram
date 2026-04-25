using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.CheckSpam;

namespace Presentation.Endpoints;

public static class CheckSpamEndpoint
{
    public static RouteGroupBuilder MapCheckSpam(this RouteGroupBuilder group)
    {
        group.MapPost("/spam", (CheckSpamRequest request, CheckSpamRequestHandle handler) =>
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
            .WithName("CheckSpam")
            .WithSummary("Check Spam")
            .WithDescription("Проверка текста на спам")
            .WithOpenApi()
            .Produces<CheckSpamResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}