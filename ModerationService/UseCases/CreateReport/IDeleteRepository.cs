namespace UseCases.CreateReport;

public interface IDeleteRepository
{
    void DeleteComment(Guid commentId);
    void DeleteRecipe(Guid recipeId);
}