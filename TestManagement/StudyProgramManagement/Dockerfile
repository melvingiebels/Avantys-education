FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StudyProgramManagement/StudyProgramManagement.csproj", "StudyProgramManagement/"]
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
