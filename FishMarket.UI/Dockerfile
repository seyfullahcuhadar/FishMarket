#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FishMarket.UI/FishMarket.UI.csproj", "FishMarket.UI/"]
COPY ["FishMarket.Infrastructure/FishMarket.Infrastructure.csproj", "FishMarket.Infrastructure/"]
COPY ["FishMarket.Domain/FishMarket.Domain.csproj", "FishMarket.Domain/"]
COPY ["FishMarket.Application/FishMarket.Application.csproj", "FishMarket.Application/"]
RUN dotnet restore "FishMarket.UI/FishMarket.UI.csproj"
COPY . .
WORKDIR "/src/FishMarket.UI"
RUN dotnet build "FishMarket.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FishMarket.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FishMarket.UI.dll"]
