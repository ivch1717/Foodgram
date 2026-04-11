namespace UseCases.GetAmountLikesByRecipeId;

public interface IGetAmountLikesByRecipeIdRepository
{
    int GetAmountLikesByRecipeId(Guid recipeId);
}
