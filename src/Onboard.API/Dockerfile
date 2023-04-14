FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Onboard.API/Onboard.API.csproj", "Onboard.API/"]
RUN dotnet restore "Onboard.API/Onboard.API.csproj"
COPY . .
WORKDIR "src/Onboard.API"
RUN dotnet build "Onboard.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboard.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboard.API.dll"]
