# Containerize the mongodb

docker run -d -p 27017:27017   mongo

# create db collection customers

# dockerize rabbitmmq

docker run -d --rm -it -p 15672:15672 -p 5672:5672 rabbitmq:3-management

# web app change the rabbitmq connecto to 
HostName = IP Address of Rabbit mq (docker inspect <containerid>)
Port = 5672

#mongodb connection string in appsettings.json

"mongodb://<ipaddressofmongodbdockercontainer>:27017"

#Build the web app for docker
***************************Dockerfile**********************

# Stage 1 - Build the app with dependencies and get the reference in a variable
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app 

# Copy everything into the App folder
COPY . ./
#USER CONTAINERADMINISTRATOR
# Restore the layers

RUN dotnet restore 

#Build and publish to out folder under app
RUN dotnet publish -c Release -o out

# Stage 2 - Use the output of the earlier build and create the image with just the dotnet runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","Ng.WebApi.MongoDb.RabbitMQ.dll"]

**************************************************************


C:\Labs\DockerLabs\Day04\Day04\Ng.WebApi.MongoDb.RabbitMQ\Ng.WebApi.MongoDb.RabbitMQ>

# build
docker image build --tag sriniiyer/ngapimongorabbit:v10 .

# run 
docker run -d -p 7071:80 sriniiyer/ngapimongorabbit:v10


#Anglar App changes
# 1 - customer.data.service.ts

   customerApiUrl = "http://localhost:7071/api/customers";

# 2 customers.component.ts

 .withUrl("http://localhost:7071/customerHub",{


