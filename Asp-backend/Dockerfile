#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app/backend
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 7000:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app/backend/src
COPY ["Asp-backend/Asp-backend.csproj", "/app/backend"]
RUN dotnet restore "/app/backend/Asp-backend.csproj"
COPY . .
WORKDIR "/app/backend/src"
RUN dotnet build "Asp-backend/Asp-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Asp-backend/Asp-backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app/backend
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Asp-backend.dll"]