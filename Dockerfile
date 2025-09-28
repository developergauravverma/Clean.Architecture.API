# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the solution file first
COPY *.sln ./

# Copy all project files
COPY Clean.API/*.csproj ./Clean.API/
COPY Clean.Core/*.csproj ./Clean.Core/
COPY Clean.Application/*.csproj ./Clean.Application/
COPY Clean.InfraStructure/*.csproj ./Clean.InfraStructure/

# Restore dependencies
RUN dotnet restore

# Copy everything else
COPY . .

# Publish the API project
RUN dotnet publish Clean.API/Clean.API.csproj -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "Clean.API.dll"]