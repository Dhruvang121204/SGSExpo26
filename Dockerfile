# -----------------------------
# Runtime image (lightweight)
# -----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# -----------------------------
# Build image
# -----------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into container
COPY . .

# Restore dependencies
RUN dotnet restore

# Build & publish
RUN dotnet publish SGSExpo26/SGSExpo26.csproj -c Release -o /app/publish

# -----------------------------
# Final runtime container
# -----------------------------
FROM base AS final
WORKDIR /app

# Copy compiled output
COPY --from=build /app/publish .

# Tell ASP.NET to listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080

# Start app
ENTRYPOINT ["dotnet", "SGSExpo26.dll"]
