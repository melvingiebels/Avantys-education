FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:3003

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StudyProgramManagement/StudyProgramManagement.csproj", "StudyProgramManagement/"]
COPY ["StudyProgramManagement.Domain/StudyProgramManagement.Domain.csproj", "StudyProgramManagement.Domain/"]
COPY ["StudyProgramManagement.Infrastructure/StudyProgramManagement.Infrastructure.csproj", "StudyProgramManagement.Infrastructure/"]
RUN dotnet restore "StudyProgramManagement/StudyProgramManagement.csproj"
COPY . .
WORKDIR "/src/StudyProgramManagement"
RUN dotnet build "StudyProgramManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyProgramManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyProgramManagement.dll"]
