
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL version="1.0" maintainer="Henrique Holtz"
WORKDIR /app
# EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PomoControl.API/PomoControl.API.csproj", "PomoControl.API/"]
COPY ["PomoControl.Core/PomoControl.Core.csproj", "PomoControl.Core/"]
COPY ["PomoControl.Domain/PomoControl.Domain.csproj", "PomoControl.Domain/"]
COPY ["PomoControl.Service/PomoControl.Service.csproj", "PomoControl.Service/"]
COPY ["PomoControl.DTO/PomoControl.DTO.csproj", "PomoControl.DTO/"]
COPY ["PomoControl.Infraestructure/PomoControl.Infraestructure.csproj", "PomoControl.Infraestructure/"]
RUN dotnet restore "PomoControl.API/PomoControl.API.csproj"

COPY . .
WORKDIR "/src/PomoControl.API"
RUN dotnet build "PomoControl.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PomoControl.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet PomoControl.API.dll
# ENTRYPOINT ["dotnet", "PomoControl.API.dll"]