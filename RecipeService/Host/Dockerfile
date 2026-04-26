FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RecipeService/Host/Host.csproj", "RecipeService/Host/"]
COPY ["RecipeService/Entities/Entities.csproj", "RecipeService/Entities/"]
COPY ["RecipeService/Infrastructure/Infrastructure.csproj", "RecipeService/Infrastructure/"]
COPY ["RecipeService/UseCases/UseCases.csproj", "RecipeService/UseCases/"]
COPY ["RecipeService/Presentation/Presentation.csproj", "RecipeService/Presentation/"]
RUN dotnet restore "RecipeService/Host/Host.csproj"
COPY . .
WORKDIR "/src/RecipeService/Host"
RUN dotnet build "./Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Host.dll"]
