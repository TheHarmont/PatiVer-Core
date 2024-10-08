#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PatiVerCore.WebApi/PatiVerCore.WebApi.csproj", "PatiVerCore.WebApi/"]
COPY ["PatiVerCore.Application/PatiVerCore.Application.csproj", "PatiVerCore.Application/"]
COPY ["PatiVerCore.Domain/PatiVerCore.Domain.csproj", "PatiVerCore.Domain/"]
COPY ["PatiVerCore.Infrastructure/PatiVerCore.Infrastructure.csproj", "PatiVerCore.Infrastructure/"]
COPY ["PatiVerCore.Persistence/PatiVerCore.Persistence.csproj", "PatiVerCore.Persistence/"]
RUN dotnet restore "./PatiVerCore.WebApi/./PatiVerCore.WebApi.csproj"
COPY . .
WORKDIR "/src/PatiVerCore.WebApi"
RUN dotnet build "./PatiVerCore.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PatiVerCore.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatiVerCore.WebApi.dll"]