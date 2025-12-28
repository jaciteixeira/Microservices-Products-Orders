# ===== Products.API/Dockerfile =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos csproj
COPY ["Products.API/Products.API.csproj", "Products.API/"]
COPY ["Products.Application/Products.Application.csproj", "Products.Application/"]
COPY ["Products.Domain/Products.Domain.csproj", "Products.Domain/"]
COPY ["Products.Infrastructure/Products.Infrastructure.csproj", "Products.Infrastructure/"]

# Restaurar dependências
RUN dotnet restore "Products.API/Products.API.csproj"

# Copiar todo o código
COPY . .

# Build
WORKDIR "/src/Products.API"
RUN dotnet build "Products.API.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "Products.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.API.dll"]