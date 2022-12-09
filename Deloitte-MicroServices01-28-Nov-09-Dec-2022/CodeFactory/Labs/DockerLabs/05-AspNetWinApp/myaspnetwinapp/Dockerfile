# Stage 1 - Build the app with dependencies and get the reference in a variable
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /App 

# Copy everything into the App folder
COPY . ./
USER CONTAINERADMINISTRATOR
# Restore the layers

RUN dotnet restore 

#Build and publish to out folder under app
RUN dotnet publish -c Release -o out

# Stage 2 - Use the output of the earlier build and create the image with just the dotnet runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet","myaspnetwinapp.dll"]


