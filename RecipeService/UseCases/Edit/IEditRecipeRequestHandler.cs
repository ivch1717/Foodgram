namespace UseCases.Edit;

public interface IEditRecipeRequestHandler
{
    EditRecipeResponse Handle(EditRecipeRequest request);
}
