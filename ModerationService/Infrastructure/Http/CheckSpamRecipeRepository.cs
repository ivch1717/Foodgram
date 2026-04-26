using System.Net.Http.Json;
using Infrastructure.Data.Dtos;
using UseCases.CheckSpam;

namespace Infrastructure.Http;

public class CheckSpamRecipeRepository : ICheckSpamRecipeRepository
{
    private readonly HttpClient _httpClient;
    public CheckSpamRecipeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public IReadOnlyCollection<SpamSample> GetLast5Recipe(Guid userId)
    {
        var result = _httpClient
            .GetFromJsonAsync<GetRecipesByUserIdResponse>($"/recipes/user/{userId}")
            .GetAwaiter()
            .GetResult();

        var recipes = result?.Recipes ?? Array.Empty<RecipeResponse>();

        return recipes
            .Take(5)
            .Select(x => new SpamSample(
                x.Name + " " + x.Ingredients + " " + x.Instructions,
                x.DateCreated
            ))
            .ToList();
    }

    private sealed record GetRecipesByUserIdResponse(
        IReadOnlyCollection<RecipeResponse> Recipes
    );
}