using Infrastructure;
using Presentation;
using UseCases.CreateComment;
using UseCases.DelComment;
using UseCases.EditComment;
using UseCases.DelLike;
using UseCases.GetAmountCommentsByRecipeId;
using UseCases.GetAmountLikesByRecipeId;
using UseCases.GetCommentsByRecipeId;
using UseCases.GetCommentsByUserId;
using UseCases.GetLikesByUserId;
using UseCases.IsRecipeLiked;
using UseCases.PutLike;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICreateCommentRequestHandle,  CreateCommentRequestHandle>();
builder.Services.AddScoped<IDelCommentRequestHandle,  DelCommentRequestHandle>();
builder.Services.AddScoped<IDelLikeRequestHandle,  DelLikeRequestHandle>();
builder.Services.AddScoped<IEditCommentRequestHandle,  EditCommentRequestHandle>();
builder.Services.AddScoped<IGetAmountCommentsByRecipeIdRequestHandle,  GetAmountCommentsByRecipeIdRequestHandle>();
builder.Services.AddScoped<IGetAmountLikesByRecipeIdRequestHandle, GetAmountLikesByRecipeIdRequestHandle>();
builder.Services.AddScoped<IGetCommentsByRecipeIdRequestHandle, GetCommentsByRecipeIdRequestHandle>();
builder.Services.AddScoped<IGetCommentsByUserIdRequestHandle, GetCommentsByUserIdRequestHandle>();
builder.Services.AddScoped<IGetLikesByUserIdRequestHandle, GetLikesByUserIdRequestHandle>();
builder.Services.AddScoped<IIsRecipeLikedRequestHandle, IsRecipeLikedRequestHandle>();
builder.Services.AddScoped<IPutLikeRequestHandle, PutLikeRequestHandle>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapInteractionsEndpoints();

app.Run();