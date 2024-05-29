# Usa a imagem base do ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5253

# Configura URLs do ASP.NET Core
ENV ASPNETCORE_URLS=http://+:5253

# Define o usuário no container
USER app

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
# Define o diretório de trabalho para a fase de build
WORKDIR /src
# Copia e restaura dependências do projeto
COPY ["project.csproj", "./"]
RUN dotnet restore "project.csproj"
# Copia todos os arquivos e compila o projeto
COPY . .
WORKDIR "/src/."
RUN dotnet build "project.csproj" -c $configuration -o /app/build

# Publica a aplicação
FROM build AS publish
ARG configuration=Release
RUN dotnet publish "project.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

# Fase final, usa a imagem base do ASP.NET Core
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Define o ponto de entrada
ENTRYPOINT ["dotnet", "project.dll"]
