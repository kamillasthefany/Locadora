#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Locadora.Presentation/Locadora.Presentation.csproj", "Locadora.Presentation/"]
COPY ["Locadora.Application/Locadora.Application.csproj", "Locadora.Application/"]
COPY ["Locadora.Domain.Core/Locadora.Domain.Core.csproj", "Locadora.Domain.Core/"]
COPY ["Locadora.Domain/Locadora.Domain.csproj", "Locadora.Domain/"]
COPY ["Locadora.Infra/Locadora.Infra.csproj", "Locadora.Infra/"]
COPY ["Locadora.Domain.Services/Locadora.Domain.Services.csproj", "Locadora.Domain.Services/"]
RUN dotnet restore "Locadora.Presentation/Locadora.Presentation.csproj"
COPY . .
WORKDIR "/src/Locadora.Presentation"
RUN dotnet build "Locadora.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locadora.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Locadora.Presentation.dll"]