namespace Entities;

public sealed class Comment
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid RecipeId { get; }
    public DateTime CreatedAt { get; }
    public string Text { get; }
    public Comment(Guid id, Guid userId, Guid recipetId, DateTime createdAt, string text)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException("Id не может быть пустым");
        }

        if (userId == Guid.Empty)
        {
            throw new ArgumentNullException("UserId не может быть пустым");
        }
        
        if (recipetId == Guid.Empty)
        {
            throw new ArgumentNullException("RecipetId не может быть пустым");
        }

        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException("Текст комментария не может быть пустым");
        }
        Id = id;
        UserId = userId;
        RecipeId = recipetId;
        CreatedAt = createdAt;
        Text = text;
    }
}