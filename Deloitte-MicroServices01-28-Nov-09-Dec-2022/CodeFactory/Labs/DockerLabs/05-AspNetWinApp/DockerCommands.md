# Build the image 

docker image build --tag sriniiyer/myaspnetwinapp:win-v11 .

# Run the image as a container

docker run -d -p 8081:80 sriniiyer/myaspnetwinapp:win-v11


# get into the container


docker container ls

docker exec -it <containerid> cmd

# push to dockerhub

docker push sriniiyer/myaspnetwinapp:win-v11


