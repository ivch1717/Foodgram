using Entities;

namespace UseCases.CreateReport;

public interface IReportRepository
{
    void AddReport(Report report);
    int GetAmountReports(Guid id, TargetType targetType);
    Report? GetReport(Guid targetId, TargetType targetType, Guid userId);
}