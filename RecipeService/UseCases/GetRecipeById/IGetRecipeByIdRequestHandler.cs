namespace UseCases.GetRecipeById;

public interface IGetRecipeByIdRequestHandler
{
    GetRecipeByIdResponse Handle(GetRecipeByIdRequest request);
}
