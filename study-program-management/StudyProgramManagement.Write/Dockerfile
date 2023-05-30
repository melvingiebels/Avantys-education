FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StudyProgramManagement.Commands/StudyProgramManagement.Commands.csproj", "StudyProgramManagement.Commands/"]
RUN dotnet restore "StudyProgramManagement.Commands/StudyProgramManagement.Commands.csproj"
COPY . .
WORKDIR "/src/StudyProgramManagement.Commands"
RUN dotnet build "StudyProgramManagement.Commands.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyProgramManagement.Commands.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyProgramManagement.Commands.dll"]
