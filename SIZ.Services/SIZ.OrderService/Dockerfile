﻿FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SIZ.OrderService.csproj", "./"]
RUN dotnet restore "./SIZ.OrderService.csproj"
COPY . .
RUN dotnet publish "./SIZ.OrderService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SIZ.OrderService.dll"]
