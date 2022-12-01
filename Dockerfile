#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "App.InterViews.Report/App.InterViews.Report.csproj"
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM base AS Final
WORKDIR /app
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "App.InterViews.Report.dll"]

