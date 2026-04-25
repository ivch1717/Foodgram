using Entities;
using Infrastructure.Data.Dtos;

namespace Infrastructure.Data.Mappers;

public static class DataMapper
{
    public static ReportDto ToDto(this Report report)
    {
        return new ReportDto(
            report.Id,
            report.TargetId,
            (int)report.Type,
            report.ReporterUserId,
            report.CreatedAt,
            report.Reason
            );
    }

    public static Report ToEntity(this ReportDto dto)
    {
        return new Report(
            dto.Id,
            dto.TargetId,
            (TargetType)dto.TargetType,
            dto.UserId,
            dto.CreatedAt,
            dto.Reason
        );
    }
}