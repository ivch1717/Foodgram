using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.Edit;

namespace Presentation.Endpoints;

public static class EditRecipeEndpoint
{
    public static RouteGroupBuilder MapEditRecipe(this RouteGroupBuilder group)
    {
        group.MapPut("", (EditRecipeRequest request, IEditRecipeRequestHandler handler) =>
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
        .WithName("EditRecipe")
        .WithSummary("Edit Recipe")
        .WithDescription("Редактирование рецепта")
        .WithOpenApi()
        .Produces<EditRecipeResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
