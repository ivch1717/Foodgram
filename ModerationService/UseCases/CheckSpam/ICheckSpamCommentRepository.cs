namespace UseCases.CheckSpam;

public interface ICheckSpamCommentRepository
{
    public IReadOnlyCollection<SpamSample> GetLast5Comments(Guid id);
}