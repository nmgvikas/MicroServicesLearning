# Get to know the docker environment

docker info

# Get the list of images in this docker engine
docker image ls

# pull image of a hello-word app from the default registry - dockerhub

docker pull hello-world:latest

# run(host) the docker image 
# Docker Images have a GUID
# When docker images are hosted they are called containers
# containers are identified by a GUI or unique name scoped to the Docker engine
docker image ls

docker run hello-world

docker container ls

# Run a mongo db server
# MongoDB + OS ()
#docker run = if not found docker pull + docker run
docker run -d  --name mymongo mongo:latest


# get the list of containers running
docker container ls

# inspect the container

docker inspect d797dd923eb2

# Get into that runnig container

docker exec -it d797dd923eb2 powershell








