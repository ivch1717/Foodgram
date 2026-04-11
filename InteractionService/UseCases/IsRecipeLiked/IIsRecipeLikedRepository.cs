namespace UseCases.IsRecipeLiked;

public interface IIsRecipeLikedRepository
{
    public bool IsRecipeLiked(Guid recipeId, Guid userId);
}
