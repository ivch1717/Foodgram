using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetCommentsByRecipeId;

namespace Presentation.Endpoints;

public static class GetCommentsByRecipeIdEndpoint
{
    public static RouteGroupBuilder MapGetCommentsByRecipeId(this RouteGroupBuilder group)
    {
        group.MapGet("recipe/{recipeId:guid}", (Guid recipeId, IGetCommentsByRecipeIdRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(new GetCommentsByRecipeIdRequest(recipeId));
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
            .WithName("GetCommentsByRecipeId")
            .WithSummary("Get Comments By Recipe Id")
            .WithDescription("Получение комментариев по идентификатору рецепта")
            .WithOpenApi()
            .Produces<GetCommentsByRecipeIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
