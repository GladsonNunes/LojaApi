# Utiliza a imagem oficial do SDK do .NET 8 para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos da solução e restaura os pacotes
COPY *.sln .
COPY LojaApi.Api/*.csproj ./LojaApi.Api/
COPY LojaApi.Application/*.csproj ./LojaApi.Application/
COPY LojaApi.Domain/*.csproj ./LojaApi.Domain/
COPY LojaApi.Infrastructure/*.csproj ./LojaApi.Infrastructure/
COPY LojaApi.Repository/*.csproj ./LojaApi.Repository/
RUN dotnet restore

# Copia tudo e compila o projeto
COPY . .
WORKDIR /src/LojaApi.Api
RUN dotnet publish -c Release -o /app/publish

# Usa imagem runtime do ASP.NET para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta padrão do container
EXPOSE 80
ENTRYPOINT ["dotnet", "LojaApi.Api.dll"]
