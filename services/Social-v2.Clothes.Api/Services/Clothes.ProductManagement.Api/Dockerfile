#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Clothes.ProductManagement.Api/Clothes.ProductManagement.Api.csproj", "Services/Clothes.ProductManagement.Api/"]
RUN dotnet restore "Services/Clothes.ProductManagement.Api/Clothes.ProductManagement.Api.csproj"
COPY . .
WORKDIR "/src/Services/Clothes.ProductManagement.Api"
RUN dotnet build "Clothes.ProductManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clothes.ProductManagement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clothes.ProductManagement.Api.dll"]