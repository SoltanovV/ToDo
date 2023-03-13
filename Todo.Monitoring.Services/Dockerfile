FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app/backend/monitoring
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 8000:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app/backend/monitoring
COPY ["Todo.Monitoring.Services/Todo.Monitoring.Services.csproj", "/app/backend/monitoring"]
RUN dotnet restore "/app/backend/monitoring/Todo.Monitoring.Services.csproj"
COPY . .
WORKDIR "/app/backend/monitoring/src"
RUN dotnet build "Todo.Monitoring.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.Monitoring.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app/backend/monitoring
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Monitoring.Services.dll"]
