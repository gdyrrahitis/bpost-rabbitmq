FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src/Rmq.Application.Consumer/Rmq.Application.Consumer.csproj", "src/Rmq.Application.Consumer/"]
RUN dotnet restore "src/Rmq.Application.Consumer/Rmq.Application.Consumer.csproj"
COPY . .
WORKDIR "/src/src/Rmq.Application.Consumer"
RUN dotnet build "Rmq.Application.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Rmq.Application.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rmq.Application.Consumer.dll"]