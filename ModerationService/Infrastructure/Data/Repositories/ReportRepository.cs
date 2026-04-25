using Entities;
using Infrastructure.Data.Db;
using Infrastructure.Data.Mappers;
using UseCases.CreateReport;

namespace Infrastructure.Data.Repositories;

public class ReportRepository(ModerationServiceDbContext db) : IReportRepository
{
    public void AddReport(Report report)
    {
        db.Reports.Add(report.ToDto());
        db.SaveChanges();
    }

    public int GetAmountReports(Guid id, TargetType targetType)
    {
        return db.Reports.Count(x => x.Id == id && x.TargetType == (int)targetType);
    }

    public Report? GetReport(Guid targetId, TargetType targetType, Guid userId)
    {
        return db.Reports.FirstOrDefault(x =>
            x.TargetId == targetId && x.TargetType == (int)targetType && x.UserId == userId)?.ToEntity();
    }
}