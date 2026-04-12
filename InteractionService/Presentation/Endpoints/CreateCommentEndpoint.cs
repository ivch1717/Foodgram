using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.CreateComment;
namespace Presentation.Endpoints;

public static class CreateCommentEndpoint
{
    public static RouteGroupBuilder MapCreateComment(this RouteGroupBuilder group)
    {
        group.MapPost("", (CreateCommentRequest request, ICreateCommentRequestHandle  handler) =>
            {
                try
                {
                    var response =  handler.Handle(request);
                    return Results.Created($"/comments/{response.CommentId}", response);
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            })
            .WithName("CreateRecipe")
            .WithSummary("Create Recipe")
            .WithDescription("Создание рецепта")
            .WithOpenApi()
            .Produces<CreateCommentResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        
        
        return group;
    }
}