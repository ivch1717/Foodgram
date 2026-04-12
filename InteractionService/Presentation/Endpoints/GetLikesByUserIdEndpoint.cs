using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetLikesByUserId;

namespace Presentation.Endpoints;

public static class GetLikesByUserIdEndpoint
{
    public static RouteGroupBuilder MapGetLikesByUserId(this RouteGroupBuilder group)
    {
        group.MapGet("", (Guid userId, IGetLikesByUserIdRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(new GetLikesByUserIdRequest(userId));
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
            .WithName("GetLikesByUserId")
            .WithSummary("Get Likes By User Id")
            .WithDescription("Получение лайков пользователя")
            .WithOpenApi()
            .Produces<GetLikesByUserIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
