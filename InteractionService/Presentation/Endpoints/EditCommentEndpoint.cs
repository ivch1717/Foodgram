using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.EditComment;

namespace Presentation.Endpoints;

public static class EditCommentEndpoint
{
    public static RouteGroupBuilder MapEditComment(this RouteGroupBuilder group)
    {
        group.MapPut("", (EditCommentRequest request, IEditCommentRequestHandle handler) =>
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
            .WithName("EditComment")
            .WithSummary("Edit Comment")
            .WithDescription("Редактирование комментария")
            .WithOpenApi()
            .Produces<EditCommentResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
