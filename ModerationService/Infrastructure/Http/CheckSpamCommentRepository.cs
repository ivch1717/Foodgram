using System.Net.Http.Json;
using Infrastructure.Data.Dtos;
using UseCases.CheckSpam;

namespace Infrastructure.Http;

public class CheckSpamCommentRepository : ICheckSpamCommentRepository
{
    private readonly HttpClient _httpClient;
    public CheckSpamCommentRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IReadOnlyCollection<SpamSample> GetLast5Comments(Guid userId)
    {
        var result = _httpClient
            .GetFromJsonAsync<GetCommentsByUserIdResponse>($"/comments/user/{userId}")
            .GetAwaiter()
            .GetResult();

        var comments = result?.Comments ?? Array.Empty<CommentResponse>();

        return comments
            .Take(5)
            .Select(x => new SpamSample(
                x.Text,
                x.CreatedAt
            ))
            .ToList();
    }
    
    private sealed record GetCommentsByUserIdResponse(
        IReadOnlyCollection<CommentResponse> Comments
    );
}

