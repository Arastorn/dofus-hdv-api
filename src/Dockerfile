ARG DOTNET_VERSION=6.0

FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-alpine as base-build
WORKDIR /app


FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} as base-runtime
EXPOSE 80
WORKDIR /app


FROM base-build AS dependencies
COPY *.sln nuget.config ./*/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done \
  && dotnet restore

FROM base-build AS source
COPY . .

FROM base-build AS build
COPY --from=dependencies /root/.nuget /root/.nuget
COPY --from=dependencies /app ./
COPY --from=source /app ./
RUN dotnet build --no-restore -c Release


FROM base-build AS test
COPY --from=dependencies /root/.nuget /root/.nuget
COPY --from=dependencies /root/.dotnet /root/.dotnet
COPY --from=build /app ./
RUN dotnet test -c Release --no-restore --no-build --logger --results-directory tests

FROM base-build AS base-publish
COPY --from=dependencies /root/.nuget /root/.nuget
COPY --from=build /app ./

FROM base-publish AS publish-api
RUN dotnet publish src/Dofus.Tools.Api/Dofus.Tools.Api.csproj --no-restore --no-build  -c Release -o out

FROM base-publish AS publish-db-migration
RUN dotnet publish src/Dofus.Tools.DbMigration/Dofus.Tools.DbMigration.csproj --no-restore --no-build -c Release -o out

FROM base-runtime AS runtime-db-migration
COPY --from=publish-db-migration /app/out ./
ENTRYPOINT ["tail", "-f", "/dev/null"]

FROM base-runtime AS runtime
ENV ConnectionStrings__AppDatabase: "User ID =dofus-tools-api-dev;Password=password;Server=db;Port=5432;Database=dofus-tools;Pooling=true;"
COPY --from=publish-api /app/out ./
ENTRYPOINT ["dotnet", "Dofus.Tools.Api.dll"]