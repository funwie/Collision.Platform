#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Collision.Platform.API/Collision.Platform.API.csproj", "Collision.Platform.API/"]
COPY ["Collision.Platform.DataAccess/Collision.Platform.DataAccess.csproj", "Collision.Platform.DataAccess/"]
COPY ["Collision.Platform.Domain/Collision.Platform.Domain.csproj", "Collision.Platform.Domain/"]
COPY ["Collision.Platform.Infrastructure/Collision.Platform.Infrastructure.csproj", "Collision.Platform.Infrastructure/"]
RUN dotnet restore "Collision.Platform.API/Collision.Platform.API.csproj"
COPY . .
WORKDIR "/src/Collision.Platform.API"
RUN dotnet build "Collision.Platform.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Collision.Platform.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Collision.Platform.API.dll"]