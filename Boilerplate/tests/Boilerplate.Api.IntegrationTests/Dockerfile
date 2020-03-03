FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnet-builder 

ARG main
ARG api

COPY ${main}*.csproj ${main}
COPY ${api}*.csproj ${api}

RUN dotnet restore ${main}

COPY ${main} ${main}
COPY ${api} ${api}

WORKDIR ${main}
RUN dotnet build