FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:3004

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestManagement/TestManagement.csproj", "TestManagement/"]
COPY ["TestManagement.CQS/TestManagement.CQS.csproj", "TestManagement.CQS/"]
COPY ["TestManagement.Infrastructure/TestManagement.Infrastructure.csproj", "TestManagement.Infrastructure/"]

RUN dotnet restore "TestManagement/TestManagement.csproj"
COPY . .
WORKDIR "/src/TestManagement"
RUN dotnet build "TestManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestManagement.dll"]
