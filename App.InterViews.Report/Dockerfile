#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
EXPOSE 80:8080
EXPOSE 443:443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["App.InterViews.Report/App.InterViews.Report.csproj", "App.InterViews.Report/"]
COPY ["App.InterViews.Report.CrossCutting/App.InterViews.Report.CrossCutting.csproj", "App.InterViews.Report.CrossCutting/"]
COPY ["App.InterViews.Report.Migrations/App.InterViews.Report.Migrations.csproj", "App.InterViews.Report.Migrations/"]
COPY ["App.InterViews.Report.Db.Infrastructure/App.InterViews.Report.Db.Infrastructure.csproj", "App.InterViews.Report.Db.Infrastructure/"]
COPY ["App.InterViews.Report.Library/App.InterViews.Report.Library.csproj", "App.InterViews.Report.Library/"]
COPY ["App.InterViews.Report.Service/App.InterViews.Report.Service.csproj", "App.InterViews.Report.Service/"]

RUN dotnet restore "./App.InterViews.Report/./App.InterViews.Report.csproj"
COPY . .
WORKDIR "/src/App.InterViews.Report"
RUN dotnet build "./App.InterViews.Report.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./App.InterViews.Report.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "App.InterViews.Report.dll"]