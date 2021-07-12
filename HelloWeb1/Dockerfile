FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HelloWeb1/HelloWeb1.csproj", "HelloWeb1/"]
RUN dotnet restore "HelloWeb1/HelloWeb1.csproj"
COPY . .
WORKDIR "/src/HelloWeb1"
RUN dotnet build "HelloWeb1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWeb1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWeb1.dll"]
