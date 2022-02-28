#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Municorn.TestApp/Municorn.TestApp.csproj", "Municorn.TestApp/"]
RUN dotnet restore "Municorn.TestApp/Municorn.TestApp.csproj"
COPY . .
WORKDIR "/src/Municorn.TestApp"
RUN dotnet build "Municorn.TestApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notification.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Municorn.TestApp.dll"]