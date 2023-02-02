FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["../software-architecture-exercises1-1/software-architecture-exercises1-1/software-architecture-exercises1-1.csproj", "../software-architecture-exercises1-1/software-architecture-exercises1-1/"]
RUN dotnet restore "../software-architecture-exercises1-1/software-architecture-exercises1-1/software-architecture-exercises1-1.csproj"
COPY . .
WORKDIR "/src/../software-architecture-exercises1-1/software-architecture-exercises1-1"
RUN dotnet build "software-architecture-exercises1-1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "software-architecture-exercises1-1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "software-architecture-exercises1-1.dll"]
