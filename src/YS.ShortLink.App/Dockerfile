﻿FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /code
COPY . .
RUN dotnet build "src/YS.ShortLink.App" -c Release -o /app/build

FROM build AS publish
WORKDIR /code
RUN dotnet publish "src/YS.ShortLink.App" -f netcoreapp3.1 -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "YS.ShortLink.App.dll"]
