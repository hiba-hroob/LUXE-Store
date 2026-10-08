FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY Webproject.csproj ./
RUN dotnet restore Webproject.csproj

COPY . .

RUN dotnet publish Webproject.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-10000}

EXPOSE 10000

ENTRYPOINT ["dotnet", "Webproject.dll"]
