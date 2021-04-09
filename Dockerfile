FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS base
WORKDIR

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["PomoControl-backend/PomoControl.API.csproj", "PomoControl.API/"]
RUN dotnet restore "PomoControl-backend/PomoControl.API.csproj"
COPY ./PomoControl.API ./PomoControl.API
WORKDIR "/src/PomoControl.API"
RUN dotnet build "PomoControl.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./CounterPage/build ./wwwroot

RUN useradd -m pomocontrol
USER pomocontrol

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet PomoControl.API.dll