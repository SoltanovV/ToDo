FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app/backend
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 7000:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app/backend/src
COPY ["AspBackend/AspBackend.csproj", "/app/backend"]
RUN dotnet restore "/app/backend/AspBackend.csproj"
COPY . .
WORKDIR "/app/backend/src"
RUN dotnet build "AspBackend/AspBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspBackend/AspBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app/backend
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspBackend.dll"]