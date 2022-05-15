#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RiseTechnology.API/RiseTechnology.API.csproj", "RiseTechnology.API/"]
COPY ["RiseTechnology.Application/RiseTechnology.Application.csproj", "RiseTechnology.Application/"]
COPY ["RiseTechnology.Domain/RiseTechnology.Domain.csproj", "RiseTechnology.Domain/"]
COPY ["RiseTechnology.Infrastructure/RiseTechnology.Infrastructure.csproj", "RiseTechnology.Infrastructure/"]
RUN dotnet restore "RiseTechnology.API/RiseTechnology.API.csproj"
COPY . .
WORKDIR "/src/RiseTechnology.API"
RUN dotnet build "RiseTechnology.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RiseTechnology.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RiseTechnology.API.dll"]
