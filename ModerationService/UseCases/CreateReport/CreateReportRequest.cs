using Entities;

namespace UseCases.CreateReport;

public sealed record CreateReportRequest(Guid TargetId, TargetType Type, Guid ReporterUserId, Guid OwnerUserId,
    DateTime CreatedAt, string Reason);