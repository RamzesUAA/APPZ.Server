#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APPZ.Server/APPZ.Server.csproj", "APPZ.Server/"]
COPY ["APPZ.Infrastructure/APPZ.Infrastructure.csproj", "APPZ.Infrastructure/"]
COPY ["APPZ.Core/APPZ.Core.csproj", "APPZ.Core/"]
RUN dotnet restore "APPZ.Server/APPZ.Server.csproj"
COPY . .
WORKDIR "/src/APPZ.Server"
RUN dotnet build "APPZ.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APPZ.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APPZ.Server.dll"]