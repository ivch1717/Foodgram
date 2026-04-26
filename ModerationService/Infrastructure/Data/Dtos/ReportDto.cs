namespace Infrastructure.Data.Dtos;

public sealed record ReportDto(
    Guid Id,
    Guid TargetId,
    int TargetType, 
    Guid UserId,
    DateTime CreatedAt,
    string Reason);