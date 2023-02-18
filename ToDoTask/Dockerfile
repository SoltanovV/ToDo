#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#WORKDIR /app
#ENV ASPNETCORE_ENVIRONMENT Development
#EXPOSE 7000:80
#
#
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#WORKDIR /src
#COPY ["AspBackend.csproj", "ToDoTask/"]
#RUN dotnet restore "ToDoTask/AspBackend.csproj"
#COPY . .
#WORKDIR "/src/ToDoTask"
#RUN dotnet build "ToDoTask/AspBackend.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AspBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AspBackend.dll"]


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app/backend
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 7000:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app/backend/src
COPY ["ToDoTask/AspBackend.csproj", "ToDoTask/"]
RUN dotnet restore "ToDoTask/AspBackend.csproj"
COPY . .
WORKDIR "/app/backend/src/ToDoTask"
RUN dotnet build "AspBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app/backend
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspBackend.dll"]