# Stage 1: Base image with runtime dependencies
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Stage 2: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["ConfigurationTool.csproj", "./"]
RUN dotnet restore "ConfigurationTool.csproj"

# Copy the rest of the application code and build it
COPY . .
RUN dotnet build "ConfigurationTool.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ConfigurationTool.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Create the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "ConfigurationTool.dll"]