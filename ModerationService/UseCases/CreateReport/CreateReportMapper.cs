using Entities;

namespace UseCases.CreateReport;

public static class CreateReportMapper
{
    public static Report ToEntitiy(CreateReportRequest request, Guid id)
    {
        return new Report(id, request.TargetId, request.Type, request.ReporterUserId, request.CreatedAt, request.Reason);
    }
}