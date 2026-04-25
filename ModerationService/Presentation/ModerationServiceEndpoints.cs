using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Presentation.Endpoints;

namespace Presentation;

public static class ModerationServiceEndpoints
{
    public static WebApplication MapModerationEndpoints(this WebApplication app)
    {
        app.MapGroup("/moderation")
            .WithTags("Moderation")
            .MapCheckContentForModeration()
            .MapCheckSpam()
            .MapCreateReport();
        
        return app;
    }
}