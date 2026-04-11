namespace UseCases.Delete;

public interface IDeleteRecipeRequestHandler
{
    DeleteRecipeResponse Handle(DeleteRecipeRequest request);
}
