FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
ARG project=MangoTestDevWeb.Api
COPY . .
RUN dotnet restore "./$project/$project.csproj"
RUN dotnet build -c Release --no-restore "./$project/$project.csproj"

FROM build AS publish
WORKDIR /src
ARG project=MangoTestDevWeb.Api
RUN dotnet publish --no-self-contained --no-build --no-restore -c Release -o /app/publish "./$project/$project.csproj"

FROM base AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MangoTestDevWeb.Api.dll"]