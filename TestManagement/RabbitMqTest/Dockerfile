FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RabbitMqTest/RabbitMqTest.csproj", "RabbitMqTest/"]
RUN dotnet restore "RabbitMqTest/RabbitMqTest.csproj"
COPY . .
WORKDIR "/src/RabbitMqTest"
RUN dotnet build "RabbitMqTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMqTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMqTest.dll"]
