FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
EXPOSE 80
EXPOSE 443


COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Realese -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "Arneg-Server.dll"]
