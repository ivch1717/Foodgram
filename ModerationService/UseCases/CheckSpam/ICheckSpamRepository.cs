namespace UseCases.CheckSpam;

public interface ICheckSpamRepository
{
    public IReadOnlyCollection<SpamSample> GetLast5Comments(Guid id);
    public IReadOnlyCollection<SpamSample> GetLast5Recipe(Guid id);
}