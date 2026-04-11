using Entities;
namespace UseCases.CheckContentForModeration;

public sealed record CheckContentForModerationRequest(Guid TargetId, TargetType Type, string? Name, string? Ingredients,
    string Text);