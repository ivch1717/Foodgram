using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UseCases.DelComment;

namespace Presentation.Endpoints;

public static class DelCommentEndpoint
{
    public static RouteGroupBuilder MapDelComment(this RouteGroupBuilder group)
    {
        group.MapDelete("/{commentId:guid}/users/{userId:guid}", (
                Guid commentId,
                Guid userId,
                IDelCommentRequestHandle handler) =>
            {
                try
                {
                    var request = new DelCommentRequest(commentId, userId);
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
            .WithName("DelComment")
            .WithSummary("Delete Comment")
            .WithDescription("Удаление комментария")
            .WithOpenApi()
            .Produces<DelCommentResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
