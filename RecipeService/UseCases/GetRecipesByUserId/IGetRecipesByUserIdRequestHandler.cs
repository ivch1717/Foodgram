namespace UseCases.GetRecipesByUserId;

public interface IGetRecipesByUserIdRequestHandler
{
    GetRecipesByUserIdResponse Handle(GetRecipesByUserIdRequest request);
}
