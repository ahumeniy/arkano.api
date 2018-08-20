FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50591
EXPOSE 44374

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY services/arkano.api/arkano.api.csproj services/arkano.api/
COPY common/arkano.common.interfaces/arkano.common.interfaces.csproj common/arkano.common.interfaces/
COPY logic/arkano.logic.common/arkano.logic.common.csproj logic/arkano.logic.common/
COPY data/arkano.data.repositories/arkano.data.repositories.csproj data/arkano.data.repositories/
COPY data/arkano.data.interfaces/arkano.data.interfaces.csproj data/arkano.data.interfaces/
COPY common/arkano.common.domain/arkano.common.domain.csproj common/arkano.common.domain/
COPY logic/arkano.logic.interfaces/arkano.logic.interfaces.csproj logic/arkano.logic.interfaces/
COPY common/arkano.common.configuration/arkano.common.configuration.csproj common/arkano.common.configuration/
COPY common/arkano.common.exceptions/arkano.common.exceptions.csproj common/arkano.common.exceptions/
RUN dotnet restore services/arkano.api/arkano.api.csproj
COPY . .
WORKDIR /src/services/arkano.api
RUN dotnet build arkano.api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish arkano.api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "arkano.api.dll"]
