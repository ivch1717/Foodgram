using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Presentation.Endpoints;

namespace Presentation;

public static class RecipeServiceEndpoints
{
    public static WebApplication MapRecipesEndpoints(this WebApplication app)
    {
        app.MapGroup("/recipes")
            .WithTags("Recipes")
            .MapCreateRecipe()
            .MapDeleteRecipe()
            .MapEditRecipe()
            .MapGetRecipeById()
            .MapGetRecipesByUserId();
        
        return app;
    }
}