FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Rmq.Application.Producer/Rmq.Application.Producer.csproj", "src/Rmq.Application.Producer/"]
RUN dotnet restore "src/Rmq.Application.Producer/Rmq.Application.Producer.csproj"
COPY . .
WORKDIR "/src/src/Rmq.Application.Producer"
RUN dotnet build "Rmq.Application.Producer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rmq.Application.Producer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rmq.Application.Producer.dll"]