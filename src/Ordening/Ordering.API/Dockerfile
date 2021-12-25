#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ordening/Ordering.API/Ordering.API.csproj", "Ordening/Ordering.API/"]
COPY ["Ordening/Ordering.Application/Ordering.Application.csproj", "Ordening/Ordering.Application/"]
COPY ["Ordening/Ordering.Domain/Ordering.Domain.csproj", "Ordening/Ordering.Domain/"]
COPY ["BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "BuildingBlocks/EventBus.Messages/"]
COPY ["Ordening/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Ordening/Ordering.Infrastructure/"]
RUN dotnet restore "Ordening/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/Ordening/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]