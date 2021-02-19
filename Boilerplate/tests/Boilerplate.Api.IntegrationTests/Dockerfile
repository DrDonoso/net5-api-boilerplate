FROM mcr.microsoft.com/dotnet/sdk:5.0.103-buster-slim AS build

WORKDIR /sln

COPY ["Boilerplate.sln", "Boilerplate.sln"]

COPY ["src/Boilerplate.Api/Boilerplate.Api.csproj", "src/Boilerplate.Api/Boilerplate.Api.csproj"]

COPY ["tests/Boilerplate.Api.IntegrationTests/Boilerplate.Api.IntegrationTests.csproj", "tests/Boilerplate.Api.IntegrationTests/Boilerplate.Api.IntegrationTests.csproj"]
COPY ["tests/Boilerplate.Api.UnitTests/Boilerplate.Api.UnitTests.csproj", "tests/Boilerplate.Api.UnitTests/Boilerplate.Api.UnitTests.csproj"]

RUN dotnet restore  "/sln/Boilerplate.sln"

COPY . .

RUN dotnet publish "/sln/tests/Boilerplate.Api.IntegrationTests/Boilerplate.Api.IntegrationTests.csproj" -c Release --no-restore -o /app

FROM mcr.microsoft.com/dotnet/sdk:5.0.103-buster-slim AS final
WORKDIR /app
COPY --from=build /app .