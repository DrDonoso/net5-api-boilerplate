FROM mcr.microsoft.com/dotnet/aspnet:5.0.3-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0.3-buster-slim AS build

WORKDIR /sln

COPY ["Boilerplate.sln", "Boilerplate.sln"]

COPY ["src/Boilerplate.Api/Boilerplate.Api.csproj", "src/Boilerplate.Api/Boilerplate.Api.csproj"]

COPY ["tests/Boilerplate.Api.IntegrationTests/Boilerplate.Api.IntegrationTests.csproj", "tests/Boilerplate.Api.IntegrationTests/Boilerplate.Api.IntegrationTests.csproj"]
COPY ["tests/Boilerplate.Api.UnitTests/Boilerplate.Api.UnitTests.csproj", "tests/Boilerplate.Api.UnitTests/Boilerplate.Api.UnitTests.csproj"]

RUN dotnet restore  "/sln/Boilerplate.sln"

COPY . .

RUN dotnet publish "/sln/src/Boilerplate.Api.UnitTests/Boilerplate.Api.UnitTests.csproj" -c Release --no-restore -o /app

FROM base as final
WORKDIR /app
COPY --from=dotnet-builder /app .