using Entities;

namespace UseCases.CheckSpam;

public sealed record CheckSpamRequest(Guid TargetId, TargetType Type, string Text, DateTime CreatedAt);