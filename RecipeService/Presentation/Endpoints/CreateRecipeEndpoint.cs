using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.Create;

namespace Presentation.Endpoints;

public static class CreateRecipeEndpoint
{
    public static RouteGroupBuilder MapCreateRecipe(this RouteGroupBuilder group)
    {
        group.MapPost("", (CreateRecipeRequest request, ICreateRecipeRequestHandler handler) =>
        {
            try
            {
                var response =  handler.Handle(request);
                return Results.Created($"/recipes/{response.Id}", response);
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
        .Produces<CreateRecipeResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);
        
        
        return group;
    }
}