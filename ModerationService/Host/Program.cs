using Infrastructure;
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapModerationEndpoints();

app.Run();