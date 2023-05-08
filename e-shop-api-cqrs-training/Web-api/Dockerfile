FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Web-api/Web-api.csproj", "Web-api/"]
RUN dotnet restore "Web-api/Web-api.csproj"
COPY . .
WORKDIR "/src/Web-api"
RUN dotnet build "Web-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web-api.dll"]
