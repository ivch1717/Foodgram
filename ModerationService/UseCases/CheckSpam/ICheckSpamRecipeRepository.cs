namespace UseCases.CheckSpam;

public interface ICheckSpamRecipeRepository
{
    public IReadOnlyCollection<SpamSample> GetLast5Recipe(Guid id);
}