FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SIZ.NotificationService.csproj", "./"]
RUN dotnet restore "./SIZ.NotificationService.csproj"
COPY . .
RUN dotnet publish "./SIZ.NotificationService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SIZ.NotificationService.dll"]
