using Infrastructure;
using Presentation;
using UseCases.Create;
using UseCases.Delete;
using UseCases.Edit;
using UseCases.GetRecipeById;
using UseCases.GetRecipesByUserId;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRecipesInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICreateRecipeRequestHandler, CreateRecipeRequestHandler>();
builder.Services.AddScoped<IDeleteRecipeRequestHandler, DeleteRecipeRequestHandler>();
builder.Services.AddScoped<IEditRecipeRequestHandler, EditRecipeRequestHandler>();
builder.Services.AddScoped<IGetRecipeByIdRequestHandler, GetRecipeByIdRequestHandler>();
builder.Services.AddScoped<IGetRecipesByUserIdRequestHandler, GetRecipesByUserIdRequestHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapRecipesEndpoints();

app.Run();
