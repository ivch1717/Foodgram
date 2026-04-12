using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.GetRecipesByUserId;

namespace Presentation.Endpoints;

public static class GetRecipesByUserIdEndpoint
{
    public static RouteGroupBuilder MapGetRecipesByUserId(this RouteGroupBuilder group)
    {
        group.MapGet("/user/{userId:guid}", (Guid userId, IGetRecipesByUserIdRequestHandler handler) =>
        {
            try
            {
                var response = handler.Handle(new GetRecipesByUserIdRequest(userId));
                return Results.Ok(response);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("GetRecipesByUserId")
        .WithSummary("Get Recipes By User Id")
        .WithDescription("Получение рецептов пользователя")
        .WithOpenApi()
        .Produces<GetRecipesByUserIdResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}
