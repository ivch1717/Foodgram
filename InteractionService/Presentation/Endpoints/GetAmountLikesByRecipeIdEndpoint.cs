using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetAmountLikesByRecipeId;

namespace Presentation.Endpoints;

public static class GetAmountLikesByRecipeIdEndpoint
{
    public static RouteGroupBuilder MapGetAmountLikesByRecipeId(this RouteGroupBuilder group)
    {
        group.MapGet("recipe/{recipeId:guid}/amount", (Guid recipeId, IGetAmountLikesByRecipeIdRequestHandle handler) =>
            {
                try
                {
                    var response = handler.Handle(new GetAmountLikesByRecipeIdRequest(recipeId));
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
            .WithName("GetAmountLikesByRecipeId")
            .WithSummary("Get Amount Likes By Recipe Id")
            .WithDescription("Получение количества лайков по идентификатору рецепта")
            .WithOpenApi()
            .Produces<GetAmountLikesByRecipeIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
