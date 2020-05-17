FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copiar csproj e restaurar dependencias

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /Api
COPY ["Api.sln", "Api.sln"]
COPY ["Api.Web/Api.Web.csproj", "Api.Web/"]
COPY ["Api.Application/Api.Application.csproj", "Api.Application/"]
COPY ["Api.Core/Api.Core.csproj", "Api.Core/"]
COPY ["Api.Domain/Api.Domain.csproj", "Api.Domain/"]
COPY ["Api.Infra.CrossCutting/Api.Infra.CrossCutting.csproj", "Api.Infra.CrossCutting/"]
COPY ["Api.Infra.Data/Api.Infra.Data.csproj", "Api.Infra.Data/"]
RUN dotnet restore "Api.Web/Api.Web.csproj"
COPY . .
WORKDIR "/Api/Api.Web"
RUN dotnet build "Api.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.Web.csproj" -c Release -o /app/publish

FROM base AS final

# Build da imagem

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build-env /app/dist .

ENTRYPOINT ["dotnet", "Api.Web.dll"]

