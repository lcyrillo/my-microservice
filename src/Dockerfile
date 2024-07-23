FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyMicroservice.csproj", "."]
RUN dotnet restore "./MyMicroservice.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "MyMicroservice.csproj" -c Release -o /app/build

ENTRYPOINT [ "dotnet run" ]

FROM build AS publish
RUN dotnet publish "MyMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyMicroservice.dll"]