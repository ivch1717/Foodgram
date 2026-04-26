using UseCases.CreateReport;

namespace Infrastructure.Http;

public class DeleteCommentRepository : IDeleteCommentRepository
{
    private readonly HttpClient _httpClient;
    public DeleteCommentRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void DeleteComment(Guid commentId, Guid userId)
    {
        _httpClient.DeleteAsync($"/comments/{commentId}/users/{userId}");
    }
}