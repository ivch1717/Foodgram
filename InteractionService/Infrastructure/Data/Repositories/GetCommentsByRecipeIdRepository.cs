using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.GetCommentsByRecipeId;

namespace Infrastructure.Data.Repositories;

internal sealed class GetCommentsByRecipeIdRepository(InteractionServiceDbContext db) : IGetCommentsByRecipeIdRepository
{
    public IReadOnlyCollection<Comment> GetCommentsByRecipeId(Guid recipeId)
    {
        return db.Comments
            .Where(x => x.RecipeId == recipeId)
            .Select(x => x.ToEntity())
            .ToList();
    }
}