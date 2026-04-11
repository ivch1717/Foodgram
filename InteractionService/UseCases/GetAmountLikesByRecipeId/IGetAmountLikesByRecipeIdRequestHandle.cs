namespace UseCases.GetAmountLikesByRecipeId;

public interface IGetAmountLikesByRecipeIdRequestHandle
{
    public GetAmountLikesByRecipeIdResponse Handle(GetAmountLikesByRecipeIdRequest request);
}
