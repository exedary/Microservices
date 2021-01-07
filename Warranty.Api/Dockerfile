#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080;http://::8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY ["Warranty.Api.csproj", "Warranty/"]
RUN dotnet restore "Warranty/Warranty.Api.csproj"
COPY . .
RUN dotnet build "Warranty.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Warranty.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Warranty.Api.dll"]