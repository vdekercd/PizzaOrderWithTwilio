#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Pizza.Cloud.IO/Pizza.Cloud.IO.csproj", "Pizza.Cloud.IO/"]
RUN dotnet restore "Pizza.Cloud.IO/Pizza.Cloud.IO.csproj"
COPY . .
WORKDIR "/src/Pizza.Cloud.IO"
RUN dotnet build "Pizza.Cloud.IO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pizza.Cloud.IO.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pizza.Cloud.IO.dll"]