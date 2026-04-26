using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using UseCases.CreateReport;

namespace Presentation.Endpoints;

public static class CreateReportEndpoint
{
    public static RouteGroupBuilder MapCreateReport(this RouteGroupBuilder group)
    {
        group.MapPost("", (CreateReportRequest request, ICreateReportRequestHandle handler) =>
        {
            try
            {
                var response = handler.Handle(request);
                return Results.Ok(response);
            }
            catch (ArgumentException ex)
            {
                return Results.BadRequest(new { error = ex.Message });
            }
        })
        .WithName("CreateReport")
        .WithSummary("Create Report")
        .WithDescription("Создание жалобы")
        .WithOpenApi()
        .Produces<CreateReportResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);
        
        
        return group;
    }
}