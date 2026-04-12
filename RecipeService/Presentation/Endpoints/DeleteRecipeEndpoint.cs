using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.Delete;

namespace Presentation.Endpoints;

public static class DeleteRecipeEndpoint
{
    public static RouteGroupBuilder MapDeleteRecipe(this RouteGroupBuilder group)
    {
        group.MapDelete("", (DeleteRecipeRequest request, IDeleteRecipeRequestHandler handler) =>
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
        .WithName("DeleteRecipe")
        .WithSummary("Delete Recipe")
        .WithDescription("Удаление рецепта")
        .WithOpenApi()
        .Produces<DeleteRecipeResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
