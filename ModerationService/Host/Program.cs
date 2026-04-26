using Infrastructure;
using Infrastructure.Http;
using Presentation;
using UseCases.CheckContentForModeration;
using UseCases.CheckSpam;
using UseCases.CreateReport;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddModerationInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICheckContentForModerationRequestHandle, CheckContentForModerationRequestHandle>();
builder.Services.AddScoped<ICheckSpamRequestHandle, CheckSpamRequestHandle>();
builder.Services.AddScoped<ICreateReportRequestHandle, CreateReportRequestHandle>();

builder.Services.AddHttpClient<IDeleteRecipeRepository, DeleteRecipeRepository>(client =>
{
    var baseUrl = builder.Configuration["Services:RecipeService:BaseUrl"];

    if (string.IsNullOrWhiteSpace(baseUrl))
        throw new InvalidOperationException("Services:RecipeService:BaseUrl is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<IDeleteCommentRepository, DeleteCommentRepository>(client =>
{
    var baseUrl = builder.Configuration["Services:InteractionService:BaseUrl"];

    if (string.IsNullOrWhiteSpace(baseUrl))
        throw new InvalidOperationException("Services:InteractionService:BaseUrl is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<ICheckSpamRecipeRepository, CheckSpamRecipeRepository>(client =>
{
    var baseUrl = builder.Configuration["Services:RecipeService:BaseUrl"];

    if (string.IsNullOrWhiteSpace(baseUrl))
        throw new InvalidOperationException("Services:RecipeService:BaseUrl is missing.");

    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddHttpClient<ICheckSpamCommentRepository, CheckSpamCommentRepository>(client =>
{
    var baseUrl = builder.Configuration["Services:InteractionService:BaseUrl"];

    if (string.IsNullOrWhiteSpace(baseUrl))
        throw new InvalidOperationException("Services:InteractionService:BaseUrl is missing.");

    client.BaseAddress = new Uri(baseUrl);
});



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapModerationEndpoints();

app.Run();