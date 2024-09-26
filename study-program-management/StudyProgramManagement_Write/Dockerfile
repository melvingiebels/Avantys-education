FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:3005

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StudyProgramManagement.API/StudyProgramManagement.API.csproj", "StudyProgramManagement.API/"]
COPY ["StudyProgramManagement.Commands/StudyProgramManagement.Commands.csproj", "StudyProgramManagement.Commands/"]
COPY ["StudyProgramManagement.Domain/StudyProgramManagement.Domain.csproj", "StudyProgramManagement.Domain/"]
COPY ["StudyProgramManagement.Infrastructure/StudyProgramManagement.Infrastructure.csproj", "StudyProgramManagement.Infrastructure/"]
RUN dotnet restore "StudyProgramManagement.API/StudyProgramManagement.API.csproj"
COPY . .
WORKDIR "/src/StudyProgramManagement.API"
RUN dotnet build "StudyProgramManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyProgramManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyProgramManagement.API.dll"]
