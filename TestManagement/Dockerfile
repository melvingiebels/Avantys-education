FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestManagement.csproj", "TestManagement/"]
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
