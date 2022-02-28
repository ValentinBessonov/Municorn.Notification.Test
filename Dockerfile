#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# copy csproj and restore
COPY *.sln .
COPY src/Municorn.TestApp/*.csproj ./Municorn.TestApp/
COPY src/Municorn.TestApp.Core/*.csproj ./Municorn.TestApp.Core/
COPY src/Municorn.TestApp.Infrastructure/*.csproj ./Municorn.TestApp.Infrastructure/
RUN dotnet restore "Municorn.TestApp/Municorn.TestApp.csproj"
RUN dotnet restore "Municorn.TestApp.Core/Municorn.TestApp.Core.csproj"
RUN dotnet restore "Municorn.TestApp.Infrastructure/Municorn.TestApp.Infrastructure.csproj"

# copy everything else and build app
COPY src/Municorn.TestApp/. ./Municorn.TestApp/
COPY src/Municorn.TestApp.Core/. ./Municorn.TestApp.Core/
COPY src/Municorn.TestApp.Infrastructure/. ./Municorn.TestApp.Infrastructure/

RUN dotnet build "Municorn.TestApp/Municorn.TestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Municorn.TestApp/Municorn.TestApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Municorn.TestApp.dll"]