FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BunkerApi/BunkerApi.csproj", "BunkerApi/"]
RUN dotnet restore "BunkerApi/BunkerApi.csproj"
COPY . .
WORKDIR "/src/BunkerApi"
RUN dotnet build "BunkerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BunkerApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BunkerApi.dll"]