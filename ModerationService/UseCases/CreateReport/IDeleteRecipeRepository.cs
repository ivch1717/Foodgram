namespace UseCases.CreateReport;

public interface IDeleteRecipeRepository
{
    void DeleteRecipe(Guid recipeId, Guid userId);
}