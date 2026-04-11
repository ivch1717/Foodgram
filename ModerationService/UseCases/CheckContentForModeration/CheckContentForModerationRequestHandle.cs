using System.Text.RegularExpressions;
using Entities;

namespace UseCases.CheckContentForModeration;

public class CheckContentForModerationRequestHandle : ICheckContentForModerationRequestHandle
{
    private List<string> _bannedWords = new List<string>(["наркотики", "18+", "порно", "секс", "хуй", "пизда", 
        "сперма", "сперма"]);

    private int CheckContent(string text)
    {
        var hasLink = Regex.IsMatch(text, @"(https?:\/\/[^\s]+)|(www\.[^\s]+)", RegexOptions.IgnoreCase);

        if (hasLink)
        {
            return 1;
        }

        var hasBannedWord = _bannedWords.Any(word =>
            text.Contains(word, StringComparison.OrdinalIgnoreCase));

        if (hasBannedWord)
        {
            return 2;
        }

        return 0;
    }
    
    public CheckContentForModerationResponse Handle(CheckContentForModerationRequest request)
    {
        int res = 0;
        if (request.Type == TargetType.Comment)
        {
            res = CheckContent(request.Text);
        }
        else
        {
            res = int.Max(int.Max(CheckContent(request.Text), CheckContent(request.Name ?? "")), CheckContent(request.Ingredients ?? ""));
        }
        switch (res)
        {
            case 0: 
                return new CheckContentForModerationResponse(false, null);
            case 1:
                return new CheckContentForModerationResponse(true, "использование подозрительных ссылок");
            default:
                return new CheckContentForModerationResponse(true, "использование нецензурных слов");
        }
    }
}