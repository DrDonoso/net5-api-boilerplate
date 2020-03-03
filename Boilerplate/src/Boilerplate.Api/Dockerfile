FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnet-builder 

ARG main

COPY ${main}*.csproj ${main}

RUN dotnet restore ${main}

COPY ${main} ${main}

RUN dotnet publish ${main} -c Release -o /build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=dotnet-builder /build .
ENTRYPOINT [ "dotnet", "Boilerplate.Api.dll"]