namespace UseCases.GetCommentsByRecipeId;

public interface IGetCommentsByRecipeIdRequestHandle
{
    public GetCommentsByRecipeIdResponse Handle(GetCommentsByRecipeIdRequest request);
}
