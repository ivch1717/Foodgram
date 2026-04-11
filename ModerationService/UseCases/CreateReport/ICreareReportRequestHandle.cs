namespace UseCases.CreateReport;

public interface ICreateReportRequestHandle
{
    CreateReportResponse Handle(CreateReportRequest request);
}