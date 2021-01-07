#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://0.0.0.0:8081;http://::8081

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY ["Warehouse.Api.csproj", "Warehouse/"]
RUN dotnet restore "Warehouse/Warehouse.Api.csproj"
COPY . .
RUN dotnet build "Warehouse.Api.csproj" -c Release -o /app/build
RUN dotnet test 

FROM build AS publish
RUN dotnet publish "Warehouse.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Warehouse.Api.dll"]