FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["src/Devops.Places.Api/Devops.Places.Api.csproj", "Devops.Places.Api/"]
COPY ["src/Devops.Places.DataAccess/Devops.Places.DataAccess.csproj", "Devops.Places.DataAccess/"]
RUN dotnet restore "Devops.Places.Api/Devops.Places.Api.csproj"

COPY src ./
WORKDIR "/src/Devops.Places.Api"
RUN dotnet build "Devops.Places.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Devops.Places.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devops.Places.Api.dll"]
