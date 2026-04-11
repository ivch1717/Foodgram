namespace UseCases.CheckContentForModeration;

public sealed record CheckContentForModerationResponse(bool ShouldDelete,
    string? Reason);