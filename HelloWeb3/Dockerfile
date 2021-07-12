FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HelloWeb3/HelloWeb3.csproj", "HelloWeb3/"]
RUN dotnet restore "HelloWeb3/HelloWeb3.csproj"
COPY . .
WORKDIR "/src/HelloWeb3"
RUN dotnet build "HelloWeb3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWeb3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWeb3.dll"]
