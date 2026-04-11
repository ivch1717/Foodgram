using Entities;

namespace UseCases.GetCommentsByRecipeId;

public interface IGetCommentsByRecipeIdRepository
{
    IReadOnlyCollection<Comment> GetCommentsByRecipeId(Guid recipeId);
}
