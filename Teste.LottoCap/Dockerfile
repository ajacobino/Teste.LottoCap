#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Teste.LottoCap.csproj", "./"]
COPY ["../Teste.LottoCap.Service/Teste.LottoCap.Service.csproj", "../Teste.LottoCap.Service/"]
COPY ["../Teste.LottoCap.CrossCutting/Teste.LottoCap.CrossCutting.csproj", "../Teste.LottoCap.CrossCutting/"]
COPY ["../Teste.LottoCap.Domain/Teste.LottoCap.Domain.csproj", "../Teste.LottoCap.Domain/"]
RUN dotnet restore "Teste.LottoCap.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Teste.LottoCap.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teste.LottoCap.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste.LottoCap.dll"]
