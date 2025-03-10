FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SIZ.IdentityService.csproj", "./"]
RUN dotnet restore "./SIZ.IdentityService.csproj"
COPY . .
RUN dotnet publish "./SIZ.IdentityService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SIZ.IdentityService.dll"]
