using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetRecipeById;

namespace Presentation.Endpoints;

public static class GetRecipeByIdEndpoint
{
    public static RouteGroupBuilder MapGetRecipeById(this RouteGroupBuilder group)
    {
        group.MapGet("/{recipeId:guid}", (Guid recipeId, IGetRecipeByIdRequestHandler handler) =>
        {
            try
            {
                var response = handler.Handle(new GetRecipeByIdRequest(recipeId));
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
        .WithName("GetRecipeById")
        .WithSummary("Get Recipe By Id")
        .WithDescription("Получение рецепта по идентификатору")
        .WithOpenApi()
        .Produces<GetRecipeByIdResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
