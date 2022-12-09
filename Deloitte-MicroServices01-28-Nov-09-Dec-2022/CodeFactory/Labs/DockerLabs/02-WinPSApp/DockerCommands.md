# Ask docker to build the image

docker image build --tag <yourdockerid>/win-ps-app:v10 .

docker image build --tag sriniiyer/win-ps-app:v10 .



# running the image 

docker run  sriniiyer/win-ps-app:v10 

# get into the container

docker exec -it <yourImageId> powershell


# push your ps app to docker hub
docker push  sriniiyer/win-ps-app:v10 

# remove the image from the local docker engine
docker rmi  sriniiyer/win-ps-app:v10 --force

# run it by pulling from docker hub
docker run  sriniiyer/win-ps-app:v10 