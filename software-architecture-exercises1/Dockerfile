FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["software-architecture-exercises1/software-architecture-exercises1.csproj", "software-architecture-exercises1/"]
RUN dotnet restore "software-architecture-exercises1/software-architecture-exercises1.csproj"
COPY . .
WORKDIR "/src/software-architecture-exercises1"
RUN dotnet build "software-architecture-exercises1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "software-architecture-exercises1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "software-architecture-exercises1.dll"]
