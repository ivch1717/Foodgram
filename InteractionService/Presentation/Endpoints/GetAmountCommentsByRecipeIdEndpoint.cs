using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetAmountCommentsByRecipeId;

namespace Presentation.Endpoints;

public static class GetAmountCommentsByRecipeIdEndpoint
{
    public static RouteGroupBuilder MapGetAmountCommentsByRecipeId(this RouteGroupBuilder group)
    {
        group.MapGet("recipe/{recipeId:guid}/amount", (Guid recipeId, IGetAmountCommentsByRecipeIdRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(new GetAmountCommentsByRecipeIdRequest(recipeId));
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
            .WithName("GetAmountCommentsByRecipeId")
            .WithSummary("Get Amount Comments By Recipe Id")
            .WithDescription("Получение количества комментариев по идентификатору рецепта")
            .WithOpenApi()
            .Produces<GetAmountCommentsByRecipeIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
