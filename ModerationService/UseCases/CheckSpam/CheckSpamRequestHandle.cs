using Entities;

namespace UseCases.CheckSpam;

public class CheckSpamRequestHandle : ICheckSpamRequestHandle
{
    ICheckSpamCommentRepository _checkSpamCommentRepository;
    ICheckSpamRecipeRepository _checkSpamRecipeRepository;

    public CheckSpamRequestHandle(ICheckSpamCommentRepository checkSpamCommentRepository,  ICheckSpamRecipeRepository checkSpamRecipeRepository)
    {
        _checkSpamCommentRepository = checkSpamCommentRepository;
        _checkSpamRecipeRepository = checkSpamRecipeRepository;
    }
    
    public CheckSpamResponse Handle(CheckSpamRequest request)
    {
        IReadOnlyCollection<SpamSample> lasts;
        if (request.Type == TargetType.Comment)
        {
            lasts = _checkSpamCommentRepository.GetLast5Comments(request.UserId);
        }
        else
        {
            lasts = _checkSpamRecipeRepository.GetLast5Recipe(request.UserId);
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