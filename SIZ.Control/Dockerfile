FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SIZ.Control/SIZ.Control.csproj", "SIZ.Control/"]
RUN dotnet restore "SIZ.Control/SIZ.Control.csproj"
COPY . .
WORKDIR "/src/SIZ.Control"
RUN dotnet build "SIZ.Control.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SIZ.Control.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SIZ.Control.dll"]
