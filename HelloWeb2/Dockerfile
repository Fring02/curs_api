FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HelloWeb2/HelloWeb2.csproj", "HelloWeb2/"]
RUN dotnet restore "HelloWeb2/HelloWeb2.csproj"
COPY . .
WORKDIR "/src/HelloWeb2"
RUN dotnet build "HelloWeb2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWeb2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWeb2.dll"]
