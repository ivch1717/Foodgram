namespace UseCases.GetAmountCommentsByRecipeId;

public interface IGetAmountCommentsByRecipeIdRepository
{
    int GetAmountCommentsByRecipeId(Guid recipeId);
}
