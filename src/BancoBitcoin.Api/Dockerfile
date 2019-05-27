FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/BancoBitcoin.Api/BancoBitcoin.Api.csproj", "src/BancoBitcoin.Api/"]
COPY ["src/BancoBitcoin.Configuration/BancoBitcoin.Configuration.csproj", "src/BancoBitcoin.Configuration/"]
COPY ["src/BancoBitcoin.Repository/BancoBitcoin.Repository.csproj", "src/BancoBitcoin.Repository/"]
COPY ["src/BancoBitcoin.Domain/BancoBitcoin.Domain.csproj", "src/BancoBitcoin.Domain/"]
COPY ["src/BancoBitcoin.Application/BancoBitcoin.Application.csproj", "src/BancoBitcoin.Application/"]
RUN dotnet restore "src/BancoBitcoin.Api/BancoBitcoin.Api.csproj"
COPY . .
WORKDIR "/src/src/BancoBitcoin.Api"
RUN dotnet build "BancoBitcoin.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BancoBitcoin.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BancoBitcoin.Api.dll"]