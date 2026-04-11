using Entities;

namespace UseCases.CheckSpam;

public class CheckSpamRequestHandle : ICheckSpamRequestHandle
{
    ICheckSpamRepository _checkSpamRepository;

    public CheckSpamRequestHandle(ICheckSpamRepository checkSpamRepository)
    {
        _checkSpamRepository = checkSpamRepository;
    }
    
    public CheckSpamResponse Handle(CheckSpamRequest request)
    {
        IReadOnlyCollection<SpamSample> lasts;
        if (request.Type == TargetType.Comment)
        {
            lasts = _checkSpamRepository.GetLast5Comments(request.TargetId);
        }
        else
        {
            lasts = _checkSpamRepository.GetLast5Recipe(request.TargetId);
        }
        foreach(var i in lasts)
        {
            if (i.Text != request.Text || request.CreatedAt - i.CreateAt > TimeSpan.FromMinutes(5))
            {
                return new CheckSpamResponse(false);
            }
        }
        return new CheckSpamResponse(true);
    }
}