using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetCommentsByUserId;

namespace Presentation.Endpoints;

public static class GetCommentsByUserIdEndpoint
{
    public static RouteGroupBuilder MapGetCommentsByUserId(this RouteGroupBuilder group)
    {
        group.MapGet("user/{userId:guid}", (Guid userId, IGetCommentsByUserIdRequestHandle handler) =>      
            {
                try
                {
                    var response = handler.Handle(new GetCommentsByUserIdRequest(userId));
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
            .WithName("GetCommentsByUserId")
            .WithSummary("Get Comments By User Id")
            .WithDescription("Получение комментариев пользователя")
            .WithOpenApi()
            .Produces<GetCommentsByUserIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
