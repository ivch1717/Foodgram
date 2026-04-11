namespace UseCases.Create;

public class CreateRecipeRequestHandler : ICreateRecipeRequestHandler
{
    private readonly ICreateRecipeRepository _repository;

    public CreateRecipeRequestHandler(ICreateRecipeRepository repository)
    {
        _repository = repository;
    }
    
    public CreateRecipeResponse Handle(CreateRecipeRequest request)
    {
        var recipy = CreateRecipeMapper.ToEntity(request, Guid.NewGuid());
        _repository.Add(recipy);
        return CreateRecipeMapper.ToResponse(recipy);
    }
}