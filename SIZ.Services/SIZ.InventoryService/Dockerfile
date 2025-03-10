FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SIZ.InventoryService.csproj", "./"]
RUN dotnet restore "./SIZ.InventoryService.csproj"
COPY . .
RUN dotnet publish "./SIZ.InventoryService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SIZ.InventoryService.dll"]
