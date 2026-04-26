using Entities;

namespace UseCases.CreateReport;

public class CreateReportRequestHandle : ICreateReportRequestHandle
{
    IReportRepository _reportRepository;
    IDeleteCommentRepository _deleteCommentRepository;
    IDeleteRecipeRepository _deleteRecipeRepository;
    public CreateReportRequestHandle(IReportRepository reportRepository, IDeleteCommentRepository deleteCommentRepository, 
        IDeleteRecipeRepository deleteRecipeRepository)
    {
        _reportRepository = reportRepository;
        _deleteCommentRepository = deleteCommentRepository;
        _deleteRecipeRepository = deleteRecipeRepository;
    }

    public CreateReportResponse Handle(CreateReportRequest request)
    {
        if (_reportRepository.GetReport(request.TargetId, request.Type, request.ReporterUserId) != null)
        {
            return new CreateReportResponse("Жалоба отклонена, вы уже отправляли жалобу ранее.");
        }
        Report report = CreateReportMapper.ToEntitiy(request, Guid.NewGuid());
        _reportRepository.AddReport(report);
        if (_reportRepository.GetAmountReports(request.TargetId, request.Type) < 2)
        {
            return new CreateReportResponse($"Жалоба номер: {report.Id} обработана.");
        }
        else
        {
            if (request.Type == TargetType.Comment)
            {
                _deleteCommentRepository.DeleteComment(request.TargetId, request.OwnerUserId);
                return new CreateReportResponse($"Жалоба номер: {report.Id} обработана. Комментарий был удален");
            }
            else
            {
                _deleteRecipeRepository.DeleteRecipe(request.TargetId, request.OwnerUserId);
                return new CreateReportResponse($"Жалоба номер: {report.Id} обработана. Рецепт был удален.");
            }
        }
    }
}