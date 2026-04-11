namespace UseCases.DelLike;

public interface IDelLikeRepository
{
    bool Check(Guid recipeId, Guid userId); 
    void Delete(Guid recipeId, Guid userId);
}
