using Entities;

namespace UseCases.CreateReport;

public class CreateReportRequestHandle : ICreateReportRequestHandle
{
    IReportRepository _reportRepository;
    IDeleteRepository _deleteRepository;
    public CreateReportRequestHandle(IReportRepository reportRepository, IDeleteRepository deleteRepository)
    {
        _reportRepository = reportRepository;
        _deleteRepository = deleteRepository;
    }

    public CreateReportResponse Handle(CreateReportRequest request)
    {
        if (_reportRepository.GetReport(request.TargetId, request.Type, request.ReporterUserId) != null)
        {
            return new CreateReportResponse("Жалоба отклонена, вы уже отправляли жалобу ранее.");
        }
        Report report = CreateReportMapper.ToEntitiy(request, Guid.NewGuid());
        _reportRepository.AddReport(report);
        if (_reportRepository.GetAmountReports(request.TargetId, request.Type) < 100)
        {
            return new CreateReportResponse($"Жалоба номер: {report.Id} обработана.");
        }
        else
        {
            if (request.Type == TargetType.Comment)
            {
                _deleteRepository.DeleteComment(request.TargetId);
                return new CreateReportResponse($"Жалоба номер: {report.Id} обработана. Комментарий был удален");
            }
            else
            {
                _deleteRepository.DeleteRecipe(request.TargetId);
                return new CreateReportResponse($"Жалоба номер: {report.Id} обработана. Рецепт был удален.");
            }
        }
    }
}