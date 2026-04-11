namespace UseCases.GetAmountCommentsByRecipeId;

public interface IGetAmountCommentsByRecipeIdRequestHandle
{
    public GetAmountCommentsByRecipeIdResponse Handle(GetAmountCommentsByRecipeIdRequest request);
}
