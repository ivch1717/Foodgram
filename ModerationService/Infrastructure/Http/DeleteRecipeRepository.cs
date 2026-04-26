using UseCases.CreateReport;

namespace Infrastructure.Http;

public class DeleteRecipeRepository : IDeleteRecipeRepository
{
    private readonly HttpClient _httpClient;

    public DeleteRecipeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void DeleteRecipe(Guid recipeId,  Guid userId)
    {
        _httpClient.DeleteAsync($"/recipes/{recipeId}/users/{userId}");
    }
}