namespace UseCases.Create;

public interface ICreateRecipeRequestHandler
{
    CreateRecipeResponse Handle(CreateRecipeRequest request);
}