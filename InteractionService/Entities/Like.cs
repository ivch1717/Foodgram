namespace Entities;

public sealed class Like
{
    public Guid UserId { get; }
    public Guid RecipetId { get; }
    public DateTime CreatedAt { get; }
    public Like(Guid userId, Guid recipetId, DateTime createdAt)
    {
        if (recipetId == Guid.Empty)
        {
            throw new ArgumentNullException("RecipetId не может быть пустым");
        }

        if (userId == Guid.Empty)
        {
            throw new ArgumentNullException("UserId не может быть пустым");
        }
        
        RecipetId = recipetId;
        UserId = userId;
        CreatedAt = createdAt;
    }
}